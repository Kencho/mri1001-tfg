using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Prueba
{
    public class PlayerVictoryState : PlayerState
    {
        public PlayerController player;

        public PlayerVictoryState(PlayerController player)
        {
            this.player = player;
            PhisicsControllerPrueba.SetVelocity(player, Vector2.zero);
        }

        public void FixedUpdateState()
        {
            
        }

        public void UpdateState()
        {
            
        }
    }
}

