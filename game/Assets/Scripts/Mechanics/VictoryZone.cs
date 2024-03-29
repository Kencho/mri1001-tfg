using Platformer.Gameplay.PlayerEvents;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.Player.PlayerStates;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            PlayerController p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                p.ChangeState(new PlayerVictoryState(p));
                PlayerEnteredVictoryZone ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
            }
        }
    }
}