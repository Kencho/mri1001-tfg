using Platformer.Core;
using Platformer.Gameplay.SceneEvents;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay.PlayerEvents
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        private const float WAIT_TIME_UNTIL_LOAD_MENU = 2f;
        public VictoryZone victoryZone;

        public override void Execute()
        {
            PlatformerModel.player.animator.SetTrigger("victory");
            PlatformerModel.player.controlEnabled = false;
            Simulation.Schedule<LoadGameMenu>(WAIT_TIME_UNTIL_LOAD_MENU);
        }
    }
}