using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Mechanics.Resources;

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
                    player.ChangeState(new PlayerStoppingState(player));
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

            if(Math.Abs(PhysicsController.GetVelocity(player).x) <= PlayerController.MAX_SPEED)
            {
                
                PhysicsController.SetVelocity(player, new Vector2(newHorizontalVelocity, PhysicsController.GetVelocity(player).y));
            }
            else
            {
                PhysicsController.ApplyFriction(player, walkFriction);
            }
            
            
        }

        public void ExitPlayerState()
        {
            
        }
    }
}
