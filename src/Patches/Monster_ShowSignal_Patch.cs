using HarmonyLib;
using MGSC;

namespace HoldToSkipTurn.Patches
{
    /// <summary>
    /// Sets the flag of whether the player has spotted an enemy this AP before the PlayerInteractionSystem.ProcessInput method is called.
    /// The game resets the internal seen flag and then immediately clears it, so have to track it this way.
    /// </summary>
    [HarmonyPatch(typeof(Monster), nameof(Monster.ShowSignal), MethodType.Getter)]
    internal static class Monster_ShowSignal_Patch
    {
        public  static bool PreviousHasSpottedEnemyThisAP = false;

        public static void Prefix(Monster __instance)
        {
            //Store this so the Postfix can abort early.
            PreviousHasSpottedEnemyThisAP = __instance?._creatures?.Player?.HasSpottedEnemyThisAP ?? false;
        }
    }
}
