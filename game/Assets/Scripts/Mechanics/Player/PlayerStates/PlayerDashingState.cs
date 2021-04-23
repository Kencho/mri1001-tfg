using Platformer.Physics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerDashingState : PlayerState
    {
        private PlayerController player;
        private const float DASH_TIME = 0.15f;
        private const float DISTANCE_OF_DASH = 2;
        private float timeDashed;
        private float dashSpeed;

        public PlayerDashingState(PlayerController player)
        {
            this.player = player;
            timeDashed = 0;
            dashSpeed = calcularDashSpeed();
            this.player.animator.SetBool("dashing", true);
        }

        public void FixedUpdateState()
        {
            if(timeDashed < DASH_TIME)
            {
                timeDashed += Time.fixedDeltaTime;
                PhisicsController.SetVelocity(player, new Vector2(dashSpeed, 0));
            }
            else
            {
                exitDash();
            }
        }

        public void UpdateState()
        {
            
        }

        private float calcularDashSpeed()
        {
            float speed = DISTANCE_OF_DASH / DASH_TIME;
            if(this.player.spriteRenderer.flipX == false)
            {
                return speed;
            }
            else
            {
                return -speed;
            }
        }

        private void exitDash()
        {
            this.player.dashing = false;
            PhisicsController.SetVelocity(this.player, Vector2.zero);
            this.player.animator.SetBool("dashing", false);
            this.player.playerState = new PlayerStopingState(this.player);
        }
    }
}

