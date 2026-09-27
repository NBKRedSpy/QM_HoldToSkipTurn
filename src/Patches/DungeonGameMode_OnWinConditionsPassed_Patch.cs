using MGSC;
using HarmonyLib;

namespace HoldToSkipTurn.Patches
{
    /// <summary>
    /// Raises the StopEventFired flag if the win conditions have been met.  This is used to stop the auto skip
    /// turn when the player has completed the mission objective.
    /// </summary>
    [HarmonyPatch(typeof(DungeonGameMode), nameof(DungeonGameMode.OnWinConditionsPassed))]
    internal static class DungeonGameMode_OnWinConditionsPassed_Patch
    {
        public static void Postfix(Monster __instance)
        {
            Monster_ShowSignal_Patch.StopEventFired = true;
        }
    }
}
