using System;
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
        float direction = 0f;
        float lastDirection = 0f;

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
            Vector2 directionVector = Vector2.zero;
            direction = player.movingDirection;
            if (direction > 0)
            {
                directionVector += Vector2.right;
            }
            if (direction < 0)
            {
                directionVector += Vector2.left;
            }

            if (-direction == lastDirection)
            {
                PhisicsController.SetVelocity(player, new Vector2(0, PhisicsController.GetVelocity(player).y));
            }
            else if (Mathf.Abs(player.rigidBody.velocity.x) < player.maxSpeed)
            {

                //Si el incremento de velocidad del Player y la velocidad maxima no son multiplos es posible que el Player no tenga una velocidad maxima uniforme
                PhisicsController.ApplyImpulse(player, directionVector * player.speedIncrement);
            }

            lastDirection = direction;
        }
    }
}
