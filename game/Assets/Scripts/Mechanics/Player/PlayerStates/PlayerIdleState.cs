using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Physics;
using Platformer.Mechanics;

namespace Platformer.Player
{
    public class PlayerIdleState : PlayerState
    {

        private PlayerController player;

        public PlayerIdleState(PlayerController player)
        {
            this.player = player;
            player.animator.SetBool("grounded", true);
            player.grounded = true;
        }

        public void UpdateState()
        {
            if (player.grounded == false)
            {
                player.playerState = new PlayerOnAirState(player);
            }
            else { 
                if (Input.GetButton("Jump"))
                {
                    player.jumping = true;
                }
                else
                {
                    if (LayerContactChecker.IsInContactWithLayer(player, "Floor") == false)
                    {
                        player.grounded = false;
                    }

                    float directionMove = Input.GetAxis("HorizontalMove");
                    if (Mathf.Abs(directionMove) > 0.001f)
                    {
                        player.playerState = new PlayerMovingState(player, directionMove);
                    }
                }
            } 
        }

        public void FixedUpdateState()
        {
            if (player.jumping)
            {
                player.jump();
            }
        }

    }
}
