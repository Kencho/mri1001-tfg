using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Prueba
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
                if (PhisicsControllerPrueba.GetVelocity(player).y < 0)
                {
                    onAir = false;
                }
            }
        }

        public void FixedUpdateState()
        {
            if (onAir)
            {
                PhisicsControllerPrueba.SimulateGarvity(player);
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
            if(Mathf.Abs(PhisicsControllerPrueba.GetVelocity(player).x) >= player.maxAirSpeed)
            {
                PhisicsControllerPrueba.SetVelocity(player, new Vector2(player.maxAirSpeed * direction, PhisicsControllerPrueba.GetVelocity(player).y));
            }
            else
            {
                PhisicsControllerPrueba.ApplyImpulse(player, new Vector2(airSpeed * direction, 0));
            }
            
            
        }
    }
}
