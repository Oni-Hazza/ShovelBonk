using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using ShovelBonk.Patches;
using System;

namespace ShovelBonk
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "com.bepinex.plugin.ShovelBonk";
        private const string modName = "Shovel Bonk";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new(modGUID);

        private static Plugin Instance;

        private ConfigEntry<bool> IsEnabled;


        private void Awake()
        {
            if (Instance == null)
                Instance = this;


            LogInfo($"{nameof(Plugin)} initiated.");

            IsEnabled = Config.Bind("General.Toggles", "Enable the bonk sound", true, "Whether or not to enable the mod");

            if (IsEnabled.Value)
            {
                LogInfo($"{nameof(IsEnabled)} is enabled");
                harmony.PatchAll(typeof(StartOfRoundPatch));
                harmony.PatchAll(typeof(Shovel_ItemActivate));
            }
            else
                LogInfo($"{nameof(Plugin)} is disabled.");
        }

        public static void LogInfo(string message) => Instance.Logger.Log(BepInEx.Logging.LogLevel.Info, message);
        public static void LogWarning(string message) => Instance.Logger.Log(BepInEx.Logging.LogLevel.Warning, message);
        public static void LogError(string message) => Instance.Logger.Log(BepInEx.Logging.LogLevel.Error, message);
        public static void LogError(Exception ex) => Instance.Logger.Log(BepInEx.Logging.LogLevel.Error, ex);

    }
}
