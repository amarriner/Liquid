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
            TileRef tile = Server.tile.At((int)Event.Position.X, (int)Event.Position.Y);
            if ((bool)base.Server.GetPlayerByName(Event.Sender.Name).PluginData["water"])
            {
                tile.SetLava(false);
                tile.SetLiquid(255);
            }
            else if ((bool)base.Server.GetPlayerByName(Event.Sender.Name).PluginData["lava"])
            {
                tile.SetLava(true);
                tile.SetLiquid(255);
            }

            base.onPlayerTileChange(Event);
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

