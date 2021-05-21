using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerStates
{
    public class PlayerVictoryState : PlayerState
    {
        public PlayerController player;

        public PlayerVictoryState(PlayerController player)
        {
            this.player = player;
        }

        public void EnterPlayerState()
        {
            PhysicsController.SetVelocity(player, Vector2.zero);
        }

        public void FixedUpdateState()
        {
            
        }

        public void UpdateState()
        {
            
        }

        public void ExitPlayerState()
        {
            
        }
    }
}

