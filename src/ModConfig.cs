using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HoldToSkipTurn.Mcm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HoldToSkipTurn
{
    public class ModConfig : PersistentConfig<ModConfig>
    {

        /// <summary>
        /// he delay in milliseconds the skip key must be held before this mod auto skips turns.
        /// </summary>
        public int SkipRepeatDelay { get; set; } = 250;

        /// <summary>
        /// When skip turn is held down, this is the delay in milliseconds before the action is repeated.
        /// </summary>
        public int SkipTurnHoldDelay { get; set; } = 1000;

        public ModConfig()
        {
        }

        public ModConfig(string configPath) : base(configPath)
        {

        }

        public void Save(string configPath)
        {
            string json = JsonConvert.SerializeObject(this, SerializerSettings);
            File.WriteAllText(Plugin.ConfigDirectories.ConfigPath, json);
        }
    }
}
