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
        public TileRef tile;

        public LiquidTile(int xIn, int yIn, TileRef tileIn)
        {
            x = xIn;
            y = yIn;
            tile = tileIn;
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
            Version = "0.1";
            TDSMBuild = 31;

            plugin = this;
        }

        public override void Enable()
        {
            Program.tConsole.WriteLine(base.Name + " enabled.");
            this.registerHook(Hooks.PLAYER_TILECHANGE);
            this.registerHook(Hooks.PLAYER_STATEUPDATE);

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
            if (Server.GetPlayerByName(Event.Sender.Name).isInOpList())
            {
                LiquidTile liquidTile = new LiquidTile(
                    (int)Event.Position.X,
                    (int)Event.Position.Y,
                    Server.tile.At((int)Event.Position.X, (int)Event.Position.Y));
      
                FillLiquid(liquidTile,
                    (bool)Server.GetPlayerByName(Event.Sender.Name).PluginData["water"],
                    (bool)Server.GetPlayerByName(Event.Sender.Name).PluginData["lava"],
                    2);
            }

            base.onPlayerTileChange(Event);
        }

        private void FillLiquid(LiquidTile tile, bool water, bool lava, int depth)
        {
            if (depth > 0)
            {
                if (water)
                {
                    tile.tile.SetLava(false);
                    tile.tile.SetLiquid(255);
                }
                else if (lava)
                {
                    tile.tile.SetLava(true);
                    tile.tile.SetLiquid(255);
                }
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

