using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace ShovelBonk.Patches
{
    [HarmonyPatch(typeof(Shovel))]
    internal class Shovel_ItemActivate
    {
        [HarmonyPatch("ItemActivate")] // When you activate the shovel item
        [HarmonyPostfix]
        static void Postfix(Shovel __instance, bool used, bool buttonDown = true)
        {
            if (AudioLoad.Clip == null)
            {
                Plugin.LogWarning($"Clip is null in memory, probably failed to find bonk.wav in plugins/ShovelSound");
                return;
            }
            if (__instance.swing.name == AudioLoad.Clip.name)
                return;
            __instance.swing = AudioLoad.Clip;
        }
    }
}
