﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics;
using Platformer.Resources;

namespace Platformer.Player
{
    public class PlayerMovingState : PlayerState
    {

        private PlayerController player;
        private float direction = 0f;
        private float walkFriction = 5;

        public PlayerMovingState(PlayerController player)
        {
            this.player = player;
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
                performMove();

                if (Math.Abs(direction) < 0.001f)
                {
                    player.playerState = new PlayerStopingState(player);
                }
            }
        }

        private void performMove()
        {
            direction = player.movingDirection;
            float newHorizontalVelocity = 0;

            if (direction > 0)
            {
                newHorizontalVelocity = Mathf.Min(direction * player.maxSpeed, player.maxSpeed);
            }
            if (direction < 0)
            {
                newHorizontalVelocity = Mathf.Max(direction * player.maxSpeed, -player.maxSpeed);
            }

            if(Math.Abs(PhisicsController.GetVelocity(player).x) <= player.maxSpeed)
            {
                
                PhisicsController.SetVelocity(player, new Vector2(newHorizontalVelocity, PhisicsController.GetVelocity(player).y));
            }
            else
            {
                PhisicsController.ApplyFriction(player, walkFriction);
            }
            
            
        }
    }
}
