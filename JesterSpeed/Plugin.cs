using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JesterSpeed.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesterSpeedMod
{
    [BepInPlugin(modGUID, modName, modVersion)]

    public class JesterSpeedBase : BaseUnityPlugin
    {
        private const string modGUID = "Poseidon.JesterSpeed";
        private const string modName = "JesterSpeed";
        private const string modVersion = "1.5.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static JesterSpeedBase Instance;

        internal ManualLogSource mls;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("JesterSpeedMod ist erfolgreich gestartet ;)");

            harmony.PatchAll(typeof(JesterSpeedBase));
            harmony.PatchAll(typeof(PlayerControlerBPatch));
            harmony.PatchAll(typeof(JesterCheckPatch));
        }

    }
}
