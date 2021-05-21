using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay.PlayerEvents
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        public override void Execute()
        {
            PlatformerModel.player.animator.SetTrigger("victory");
            PlatformerModel.player.controlEnabled = false;
            Simulation.Schedule<LoadGameMenu>(2f);
        }
    }
}