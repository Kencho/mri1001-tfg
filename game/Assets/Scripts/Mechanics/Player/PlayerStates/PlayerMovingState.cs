using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics;
using Platformer.Resources;
using Platformer.Player;

namespace Platformer.Mechanics.Player.PlayerStates
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

        public void EnterPlayerState()
        {
            
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
                performMove();

                if (Math.Abs(direction) < 0.001f)
                {
                    player.ChangeState(new PlayerStopingState(player));
                }
            }
        }

        private void performMove()
        {
            direction = player.MovingDirection;
            float newHorizontalVelocity = 0;

            if (direction > 0)
            {
                newHorizontalVelocity = Mathf.Min(direction * PlayerController.MAX_SPEED, PlayerController.MAX_SPEED);
            }
            if (direction < 0)
            {
                newHorizontalVelocity = Mathf.Max(direction * PlayerController.MAX_SPEED, -PlayerController.MAX_SPEED);
            }

            if(Math.Abs(PhisicsController.GetVelocity(player).x) <= PlayerController.MAX_SPEED)
            {
                
                PhisicsController.SetVelocity(player, new Vector2(newHorizontalVelocity, PhisicsController.GetVelocity(player).y));
            }
            else
            {
                PhisicsController.ApplyFriction(player, walkFriction);
            }
            
            
        }

        public void ExitPlayerState()
        {
            
        }
    }
}
