using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;

namespace Platformer.Player
{
    public class PlayerDeadState : PlayerState
    {

        private PlayerController player;

        public PlayerDeadState(PlayerController player)
        {
            this.player = player;
            player.grounded = true;
            PhisicsController.SetVelocity(player, Vector2.zero);
        }

        public void FixedUpdateState()
        {
            
        }

        public void UpdateState()
        {
            
        }
    }
}

