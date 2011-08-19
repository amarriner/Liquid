A plugin for TDSM to manipulate liquids
author: amarriner

Right now there is one command called liquid. It takes zero or one parameters. Valid values for the parameter are water, 
lava or off. If you run /liquid water or /liquid lava, everytime a PLAYERTILECHANGE event occurs, water or lava respectively
will be created. Running /liquid or /liquid off stops this behavior.