using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesterSpeed.Patches
{
    [HarmonyPatch(typeof(JesterAI))]

    internal class JesterCheckPatch
    {
        private static int previousStateValue;
        private static float speed;
        private static ulong targetID;
        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        
        public static void getState(ref int ___previousState, JesterAI __instance)
        {
            previousStateValue = ___previousState;
            speed = __instance.agent.speed;
            targetID = __instance.targetPlayer.playerClientId;
            Console.WriteLine("Jester: " + __instance.targetPlayer.playerClientId);
        }

        public static int getPreviousStateValue()
        {
            return previousStateValue;
        }
        public static float getJesterAgentSpeed()
        {
            return speed;
        }
        public static ulong getJesterAgentTargetID()
        {
            return targetID;
        }
    }
}
