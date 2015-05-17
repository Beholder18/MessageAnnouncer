﻿using Rocket.Unturned;
using SDG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unturned.ROCKS.MessageAnnouncer
{
    public class RocketTextCommand : Command
    {
        private List<string> text;

        public RocketTextCommand(string commandName,string commandHelp,List<string> text)
        {
            base.commandName = commandName;
            base.commandHelp = commandHelp;
            base.commandInfo = base.commandName + " - " + base.commandHelp;
            this.text = text;
        }

        protected override void execute(Steamworks.CSteamID caller, string command)
        {
            foreach (string l in text) {
                RocketChat.Say(caller, l);
            }
        }
    }
}
