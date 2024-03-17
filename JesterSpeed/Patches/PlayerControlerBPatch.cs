using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JesterSpeed.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]

    internal class PlayerControlerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        static void speedBoost(ref float ___sprintMeter, ref float ___sprintMultiplier, ref bool ___isSprinting ,ref ulong ___playerClientId)
        {
            if (JesterCheckPatch.getPreviousStateValue() == 2 && (___playerClientId == JesterCheckPatch.getJesterAgentTargetID()))
            {
                ___sprintMeter = 1f;
                if (___isSprinting)
                {
                    ___sprintMultiplier = Math.Max((JesterCheckPatch.getJesterAgentSpeed()/18)*5, 1);
                    //Console.WriteLine(Math.Max((JesterCheckPatch.getJesterAgentSpeed()/18)*5, 1));
                }
                else
                {
                    ___sprintMultiplier = 1f;
                }
            }
        }


    }
}
