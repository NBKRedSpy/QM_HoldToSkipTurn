using HarmonyLib;
using MGSC;
using System.Diagnostics;

namespace HoldToSkipTurn.Patches
{

    /// <summary>
    /// The primary "skip turn until spotted" patch.  This is called every frame, and checks if the skip turn key is being held 
    /// down.  If it is, it will skip the player's turn every 250ms until an enemy is spotted.
    /// </summary>
    [HarmonyPatch(typeof(PlayerInteractionSystem), nameof(PlayerInteractionSystem.ProcessInput))]
    public static class PlayerInteractionSystem_ProcessInput_Patch
    {
        /// <summary>
        /// Determines if the skip turn is held without affecting the normal skip turn behavior.
        /// </summary>
        private static Stopwatch SkipTurnKeyHeld = new Stopwatch();

        /// <summary>
        /// The frequence of the skip turn repeat.
        /// </summary>
        private static Stopwatch RepeatTimer = new Stopwatch();

        public static void Prefix(Creatures creatures)
        {
            InputController inputController = SingletonMonoBehaviour<InputController>.Instance;

            const string SkipTurnKeyId = "SkipTurn";  //The game's key bind identifier for the skip turn key.

            if (inputController.IsKeyDown(SkipTurnKeyId))
            {
                SkipTurnKeyHeld.Restart();
                RepeatTimer.Reset();
            }
            else if(inputController.IsKeyUp(SkipTurnKeyId))
            {
                SkipTurnKeyHeld.Reset();
                RepeatTimer.Reset();
            }
            else if(inputController.IsKey(SkipTurnKeyId) && SkipTurnKeyHeld.ElapsedMilliseconds > Plugin.Config.SkipTurnHoldDelay)
            {
                if (!RepeatTimer.IsRunning)
                {
                    RepeatTimer.Start();
                }

                Player player = creatures.Player;

                //This works if they see the enemy, but not if signaled.
                if (CreatureSystem.IsSeeMonsters(player._creatures, player._mapGrid) || Monster_ShowSignal_Patch.PreviousHasSpottedEnemyThisAP)
                {

                    Monster_ShowSignal_Patch.PreviousHasSpottedEnemyThisAP = false;
                    

                    //new enemy has been spotted.  Stop the auto skip turn.
                    SkipTurnKeyHeld.Reset();
                    RepeatTimer.Stop();
                    return;
                }

                //Skip the turn.  
                //  Note that this won't conflict with the game's existing skip turn as the game uses IsKeyDown, and is immediately callable at the start
                //  of the target function.
                if (RepeatTimer.ElapsedMilliseconds > Plugin.Config.SkipRepeatDelay) // Adjust the repeat interval as needed
                {
                    PlayClickSound();
                    creatures.Player.SkipTurn();
                    RepeatTimer.Restart();
                }
            }   
        }

        private static void PlayClickSound()
        {
            SingletonMonoBehaviour<SoundController>.Instance.PlayUiSound(SingletonMonoBehaviour<SoundsStorage>.Instance.ButtonClick);
        }

    }
}
