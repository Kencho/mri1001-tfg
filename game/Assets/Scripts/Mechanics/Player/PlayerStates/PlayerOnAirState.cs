using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerStates
{
    /// <summary>
    /// State the PlayerController is in when it is on Air
    /// </summary>
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

        /// <summary>
        /// Performs the Movement in the air
        /// </summary>
        private void AerialMovement()
        {
            if(Mathf.Abs(PhysicsController.GetVelocity(player).x) >= PlayerController.MAX_AIR_SPEED)
            {
                PhysicsController.SetVelocity(player, new Vector2(PlayerController.MAX_AIR_SPEED * player.MovingDirection, PhysicsController.GetVelocity(player).y));
            }
            else
            {
                PhysicsController.ApplyImpulse(player, new Vector2(airSpeed * player.MovingDirection, 0));
            }
            
            
        }

        public void ExitPlayerState()
        {
            
        }
    }
}
