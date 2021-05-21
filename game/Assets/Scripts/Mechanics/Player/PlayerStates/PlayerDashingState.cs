﻿using Platformer.Mechanics.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerStates
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
        }

        public void EnterPlayerState()
        {
            timeDashed = 0;
            dashSpeed = CalculateDashSpeed();
            this.player.animator.SetBool("dashing", true);
        }

        public void FixedUpdateState()
        {
            if (timeDashed < DASH_TIME)
            {
                timeDashed += Time.fixedDeltaTime;
                PhysicsController.SetVelocity(player, new Vector2(dashSpeed, 0));
            }
            else
            {
                this.player.ChangeState(new PlayerStoppingState(this.player));
            }
            
        }

        public void UpdateState()
        {
            
        }

        private float CalculateDashSpeed()
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

        public void ExitPlayerState()
        {
            this.player.animator.SetBool("dashing", false);
        }
    }
}

