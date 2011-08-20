using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Terraria_Server;
using System.Threading;
using Terraria_Server.Collections;
using Terraria_Server.Commands;
using Terraria_Server.Misc;
using Terraria_Server.Logging;
using Terraria_Server.RemoteConsole;
using Terraria_Server.WorldMod;
using Terraria_Server.Definitions;
using Terraria_Server.Plugin;

namespace Liquid.Commands
{
    public class Commands
    {
        public static void liquid(Server server, ISender sender, ArgumentList args)
        {
            String waterlava;
            Player player = server.GetPlayerByName(sender.Name);
            if (args.TryGetString(0, out waterlava))
            {
                switch (waterlava.ToUpper())
                {
                    case "WATER":
                    case "LAVA":
                        player.PluginData["water"] = false;
                        player.PluginData["lava"] = false;
                        player.PluginData[waterlava.ToLower()] = true;
                        player.sendMessage("You are now spawning " + waterlava.ToLower(), new Color(100, 250, 100));
                        break;
                    case "OFF":
                        player.PluginData["water"] = false;
                        player.PluginData["lava"] = false;
                        player.sendMessage("You are no longer spawning water or lava", new Color(100, 250, 100));
                        break;
                    default:
                        throw new CommandError("Parameter must be WATER, LAVA or OFF");
                }
            }
            else
            {
                player.PluginData["water"] = false;
                player.PluginData["lava"] = false;
                player.sendMessage("You are no longer spawning water or lava", new Color(100, 250, 100));
            }
        }
    }
}

