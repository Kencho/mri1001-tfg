﻿using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerStates
{
    /// <summary>
    /// State the PlayerController is in when it is idle in the ground
    /// </summary>
    public class PlayerIdleState : PlayerState
    {

        private PlayerController player;

        public PlayerIdleState(PlayerController player)
        {
            this.player = player;
        }

        public void EnterPlayerState()
        {
            if (PhysicsController.GetVelocity(player).x != 0)
            {
                this.player.ChangeState(new PlayerStoppingState(this.player));
            }
        }

        public void UpdateState()
        {
            
        }

        public void FixedUpdateState()
        {
            if(player.Grounded == false)
            {
                player.ChangeState(new PlayerOnAirState(player));
            }
            else
            {
                if (Mathf.Abs(player.MovingDirection) > 0.001f)
                {
                    player.ChangeState(new PlayerMovingState(player));
                }
                
            }
            
        }

        public void ExitPlayerState()
        {
            
        }
    }
}
