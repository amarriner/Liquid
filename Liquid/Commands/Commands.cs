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
                    case "OFF":
                        player.PluginData["water"] = false;
                        player.PluginData["lava"] = false;
                        player.PluginData[waterlava.ToLower()] = true;
                        switch (waterlava.ToUpper())
                        {
                            case "WATER":
                            case "LAVA":
                                player.sendMessage("You are now spawning " + waterlava.ToLower());    
                                break;
                            default:
                                player.sendMessage("You are no longer spawning water or lava");
                                break;
                        }
                        break;
                    default:
                        throw new CommandError("Parameter must be WATER, LAVA or OFF");
                }
            }
            else
            {
                player.PluginData["water"] = false;
                player.PluginData["lava"] = false;
                player.sendMessage("You are no longer spawning water or lava");
            }
        }
    }
}

