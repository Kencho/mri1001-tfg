using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Prueba
{

    public class PlayerStopingState : PlayerState
    {

        private PlayerController player;
        private float friction = 25f;

        public PlayerStopingState(PlayerController player)
        {
            this.player = player;
            player.grounded = true;
        }

        public void UpdateState()
        {

            if (Mathf.Abs(player.rigidBody.velocity.x) < 0.001f)
            {
                player.playerState = new PlayerIdleState(player);
            }
            if (LayerContactChecker.IsInContactWithLayer(player, "Floor") == false)
            {
                player.playerState = new PlayerOnAirState(player);
            }
            
        }

        public void FixedUpdateState()
        {
            PhisicsControllerPrueba.ApplyFriction(player, friction);
        }
    }
}

