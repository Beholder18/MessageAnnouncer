﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steamworks;
using SDG;
using System.Timers;
using System.IO;
using System.Reflection;
using Rocket.RocketAPI;

namespace unturned.ROCKS.MessageAnnouncer
{
    public class MessageAnnouncer : RocketPlugin
    {
        public int lastindex = 0;
        public DateTime lastmessage = DateTime.Now;
        private Configuration configuration;

        public void Load()
        {
            try
            {
                SDG.Steam.serverConnected += printMessage;
                SDG.Steam.serverDisconnected += printMessage;

                configuration = (Configuration)(new Configuration()).LoadConfiguration();

                lastmessage = DateTime.Now - TimeSpan.FromMinutes(configuration.Interval);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        private void printMessage(CSteamID id)
        {
            try
            {
                if ((DateTime.Now - lastmessage).TotalMinutes > configuration.Interval)
                {
                    if (lastindex > (configuration.Messages.Length - 1)) lastindex = 0;
                    string message = configuration.Messages[lastindex];
                    ChatManager.say(message);
                    Logger.Log(message);
                    lastmessage = DateTime.Now;
                    lastindex++;
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }

        public string Author
        {
            get { return "fr34kyn01535"; }
        }

        public string Name
        {
            get { return Assembly.GetExecutingAssembly().GetName().Name.ToString(); }
        }

        public string Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }
    }
}
