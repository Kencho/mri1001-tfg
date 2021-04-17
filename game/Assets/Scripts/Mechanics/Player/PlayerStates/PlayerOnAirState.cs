using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics;
using Platformer.Resources;

namespace Platformer.Player
{
    public class PlayerOnAirState : PlayerState
    {

        PlayerController player;
        private float airSpeed = 1f;

        public PlayerOnAirState(PlayerController player)
        {
            this.player = player;
            this.player.grounded = false;
            this.player.jumping = false;
            this.player.animator.SetBool("grounded", false);
        }

        public void UpdateState()
        {
            if (LayerContactChecker.IsInContactWithLayer(player, "Floor") == true)
            {
                if (PhisicsController.GetVelocity(player).y <= 0)
                {
                    player.grounded = true;
                }
            }
        }

        public void FixedUpdateState()
        {
            if (player.grounded == false)
            {
                MoveInAir();
            }
            else
            {
                player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, 0);
                player.playerState = new PlayerStopingState(player);
            }
        }

        private void MoveInAir()
        {
            int direction = Mathf.CeilToInt(Input.GetAxis("HorizontalMove"));
            if(Mathf.Abs(PhisicsController.GetVelocity(player).x) >= player.maxAirSpeed)
            {
                PhisicsController.SetVelocity(player, new Vector2(player.maxAirSpeed * direction, PhisicsController.GetVelocity(player).y));
            }
            else
            {
                PhisicsController.ApplyImpulse(player, new Vector2(airSpeed * direction, 0));
            }
            
            
        }
    }
}
