using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace ShovelBonk.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        [HarmonyPatch("Start")] // this prefix activates when loading into a game
        static void Prefix() => AudioLoad.Load();
    }
}
