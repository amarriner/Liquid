#LIQUID

Since I'm interested in learning about creating plugins for TDSM, I checked the requested plugins thread and found one asking for a way to spawn water or lava and decided to give it a shot. I'm a C#, TDSM, Terraria neophyte so I'm learning as I go, but here's what I have so far.

Currently the Liquid plugin is version 0.1, and just trying to get off the ground. At the moment it adds one command called /liquid. The command takes an optional parameter. You must be an OP to use the command. Running it like so:

/liquid water

or 

/liquid lava

will flip a flag such that when a PLAYERTILECHANGE event occurs water or lava respectively is spawned. This means you should be able to dig a hole and simultaneously fill it with the liquid you want. Running the command like this:

/liquid off

or with no parameter turns off this behavior.

As I said, I'm pretty new to this so if there's something I should be doing differently in the code, please let me know. Also I imagine this will be relatively buggy so as issues arise let me know that as well. Otherwise, enjoy! 

##SOURCE
https://github.com/amarriner/Liquid

##DOWNLOAD
http://awbw.amarriner.com/terraria/Liquid.zip

##CHANGELOG

**0.2.1**

* Updated for TDSM Build 32

**0.2**

* Fixed a bug where the plugin would throw an exception before running the /liquid command because it was trying to access a null object
* Refactored some code in preparation for the fill command.
* Changed the message color to green for better readability

**0.1**

* Initial Release