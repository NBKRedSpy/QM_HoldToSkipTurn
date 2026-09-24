using HarmonyLib;
using ModConfigMenu;
using ModConfigMenu.Contracts;
using ModConfigMenu.Objects;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using HoldToSkipTurn.Mcm;

namespace HoldToSkipTurn
{
    /// <summary>
    /// Responsible for mapping the ModConfig to the MCM configuration menu.  
    /// </summary>
    internal class McmConfiguration : McmConfigurationBase
    {

        public McmConfiguration(ModConfig config) : base (config) { }

        /// <summary>
        /// Registers the mod configuration with the Mod Config Menu API. This method is called when the mod is loaded and allows you to define the configuration options that will be available to users in the mod configuration menu.
        /// </summary>
        public override void Configure()
        {

            //---------- Important!  Uncomment this code if to add MCM configuration support.

            ModConfig defaults = new ModConfig();

            ModConfigMenuAPI.RegisterModConfig("HoldToSkipTurn", new List<IConfigValue>()
            {
                //Note that MCM does support color codes, as shown below.

                new ConfigValue("__RestartNote", @"<color=#FF0000>The game must be restarted if any changes are made.</color>", "Restart"),

                CreateConfigProperty(nameof(ModConfig.SkipTurnHoldDelay),
                "The delay in milliseconds before the skip key can be held down to skip turns.  This is to prevent accidental double presses.",
                "Skip Turn Hold Delay (ms)", 50, 3000),

                CreateConfigProperty(nameof(ModConfig.SkipRepeatDelay),
                    "When skip turn is held down, this is the delay in milliseconds before the action is repeated.",
                    "Skip Repeat Delay (ms)",50, 3000),

            }, OnSave);
        }
         
    }
}
