using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Terraria_Server;
using Terraria_Server.Plugin;
using Terraria_Server.Collections;
using Terraria_Server.Commands;
using Terraria_Server.Events;
using Terraria_Server.Logging;

namespace Liquid
{
    public struct LiquidTile
    {
        public int x, y;
        public TileRef tileRef;

        public LiquidTile(int xIn, int yIn, TileRef tileIn)
        {
            x = xIn;
            y = yIn;
            tileRef = tileIn;
        }

        public LiquidTile(LiquidTile tileIn)
        {
            this = tileIn;
        }
    }

    public class Liquid : Plugin
    {
        public static Liquid plugin;

        public override void Load()
        {
            Name = "Liquid";
            Description = "A plugin to manipulate liquids";
            Author = "amarriner";
            Version = "0.2.2";
            TDSMBuild = 33;

            plugin = this;
        }

        public override void Enable()
        {
            Program.tConsole.WriteLine(base.Name + " enabled.");
            this.registerHook(Hooks.PLAYER_TILECHANGE);

            AddCommand("liquid")
                .WithAccessLevel(AccessLevel.OP)
                .WithDescription("Spawn Water or Lava")
                .WithHelpText("/liquid water|lava|off")
                .Calls(Commands.Commands.liquid);
        }

        public override void Disable()
        {
            Program.tConsole.WriteLine(base.Name + " disabled.");
        }

        public override void onPlayerTileChange(PlayerTileChangeEvent Event)
        {
            Player player = Server.GetPlayerByName(Event.Sender.Name);
            bool water = player.PluginData.ContainsKey("water") ? (bool)player.PluginData["water"] : false;
            bool lava = player.PluginData.ContainsKey("lava") ? (bool)player.PluginData["lava"] : false;

            if (player.isInOpList() && (water || lava))
            {
                LiquidTile liquidTile = new LiquidTile(
                    (int)Event.Position.X,
                    (int)Event.Position.Y,
                    Server.tile.At((int)Event.Position.X, (int)Event.Position.Y));
      
                FillLiquid(liquidTile,
                    water,
                    lava);
            }

            base.onPlayerTileChange(Event);
        }

        private void FillLiquid(LiquidTile tile, bool water, bool lava)
        {
            if (water)
            {
                tile.tileRef.SetLava(false);
                tile.tileRef.SetLiquid(255);
            }
            else if (lava)
            {
                tile.tileRef.SetLava(true);
                tile.tileRef.SetLiquid(255);
            }
        }

        private static void CreateDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
    }
}

