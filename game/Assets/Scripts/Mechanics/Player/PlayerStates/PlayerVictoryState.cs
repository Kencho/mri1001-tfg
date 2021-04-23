using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;

namespace Platformer.Player
{
    public class PlayerVictoryState : PlayerState
    {
        public PlayerController player;

        public PlayerVictoryState(PlayerController player)
        {
            this.player = player;
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

