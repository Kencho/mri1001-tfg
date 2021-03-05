using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay;

namespace Platformer.Prueba
{
    public class PlayerIdleState : PlayerState
    {

        private PlayerController player;

        public PlayerIdleState(PlayerController player)
        {
            this.player = player;
            player.animator.SetBool("grounded", true);
            PhisicsControllerPrueba.SetVelocity(player, Vector2.zero);
            player.grounded = true;
        }

        public void UpdateState()
        {
            if (Input.GetButton("Jump"))
            {
                player.grounded = false;
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

        public void FixedUpdateState()
        {
            if (!player.grounded)
            {
                if (player.jumping)
                {
                    player.jump();
                }
                player.playerState = new PlayerOnAirState(player);
            }
        }

    }
}
