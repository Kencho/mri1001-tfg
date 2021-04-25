using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Physics;
using Platformer.Mechanics;
using Platformer.Resources;

namespace Platformer.Player
{
    public class PlayerIdleState : PlayerState
    {

        private PlayerController player;

        public PlayerIdleState(PlayerController player)
        {
            this.player = player;
            if (PhisicsController.GetVelocity(player).x != 0)
            {
                this.player.playerState = new PlayerStopingState(this.player);
            }
            this.player.animator.SetBool("grounded", true);
        }

        public void UpdateState()
        {
            
        }

        public void FixedUpdateState()
        {
            if(player.Grounded == false)
            {
                player.playerState = new PlayerOnAirState(player);
            }
            else
            {
                if (Mathf.Abs(player.movingDirection) > 0.001f)
                {
                    player.playerState = new PlayerMovingState(player);
                }
                
            }
            
        }

    }
}
