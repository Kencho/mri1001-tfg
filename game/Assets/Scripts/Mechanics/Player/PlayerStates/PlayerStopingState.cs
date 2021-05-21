﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics;
using Platformer.Resources;
using Platformer.Player;

namespace Platformer.Mechanics.Player.PlayerStates
{

    public class PlayerStopingState : PlayerState
    {

        private PlayerController player;
        private float friction = 25;

        public PlayerStopingState(PlayerController player)
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
            if(player.MovingDirection != 0)
            {
                player.ChangeState(new PlayerMovingState(player));
            }
            else
            {
                PhisicsController.ApplyFriction(player, friction);
                if (Mathf.Abs(player.rigidBody.velocity.x) < 0.001f)
                {
                    player.ChangeState(new PlayerIdleState(player));
                }
                if (player.Grounded == false)
                {
                    player.ChangeState(new PlayerOnAirState(player));
                }
            }
            
        }

        public void ExitPlayerState()
        {
            PhisicsController.SetVelocity(player, new Vector2(0, PhisicsController.GetVelocity(player).y));
        }
    }
}

