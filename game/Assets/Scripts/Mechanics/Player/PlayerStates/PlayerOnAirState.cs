using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics;

namespace Platformer.Player
{
    public class PlayerOnAirState : PlayerState
    {

        PlayerController player;
        private bool onAir = true;
        private float airSpeed = 1f;

        public PlayerOnAirState(PlayerController player)
        {
            player.grounded = false;
            this.player = player;
            player.animator.SetBool("grounded", false);
        }

        public void UpdateState()
        {
            if(LayerContactChecker.IsInContactWithLayer(player, "Floor") == false)
            {
                onAir = true;
            }
            else
            {
                if (PhisicsController.GetVelocity(player).y <= 0)
                {
                    onAir = false;
                }
            }
        }

        public void FixedUpdateState()
        {
            if (onAir)
            {
                MoveInAir();
            }
            else
            {
                player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, 0);
                player.playerState = new PlayerIdleState(player);
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
