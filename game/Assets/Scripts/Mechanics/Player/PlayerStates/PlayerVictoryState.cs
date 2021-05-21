using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;

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
            PhisicsController.SetVelocity(player, Vector2.zero);
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

