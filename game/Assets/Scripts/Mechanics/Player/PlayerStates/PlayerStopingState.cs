using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics;
using Platformer.Resources;

namespace Platformer.Player
{

    public class PlayerStopingState : PlayerState
    {

        private PlayerController player;
        private float friction = 25;

        public PlayerStopingState(PlayerController player)
        {
            this.player = player;
            player.grounded = true;
        }

        public void UpdateState()
        {
            
        }

        public void FixedUpdateState()
        {
            PhisicsController.ApplyFriction(player, friction);
            if (Mathf.Abs(player.rigidBody.velocity.x) < 0.001f)
            {
                PlayerController.print("quieto");
                player.playerState = new PlayerIdleState(player);
            }
            if (LayerContactChecker.IsInContactWithLayer(player, "Floor") == false)
            {
                player.playerState = new PlayerOnAirState(player);
            }
        }
    }
}

