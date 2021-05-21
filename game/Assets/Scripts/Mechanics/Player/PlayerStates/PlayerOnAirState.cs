using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics;
using Platformer.Resources;

namespace Platformer.Mechanics.Player.PlayerStates
{
    public class PlayerOnAirState : PlayerState
    {

        PlayerController player;
        private float airSpeed = 1f;

        public PlayerOnAirState(PlayerController player)
        {
            this.player = player;
        }

        public void EnterPlayerState()
        {
            
        }

        public void UpdateState()
        {

        }

        public void FixedUpdateState()
        {
            if (player.Grounded == false)
            {
                AerialMovement();
            }
            else
            {
                player.ChangeState(new PlayerStoppingState(player));
            }
        }

        private void AerialMovement()
        {
            if(Mathf.Abs(PhisicsController.GetVelocity(player).x) >= PlayerController.MAX_AIR_SPEED)
            {
                PhisicsController.SetVelocity(player, new Vector2(PlayerController.MAX_AIR_SPEED * player.MovingDirection, PhisicsController.GetVelocity(player).y));
            }
            else
            {
                PhisicsController.ApplyImpulse(player, new Vector2(airSpeed * player.MovingDirection, 0));
            }
            
            
        }

        public void ExitPlayerState()
        {
            
        }
    }
}
