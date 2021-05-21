using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerStates
{

    public class PlayerStoppingState : PlayerState
    {

        private PlayerController player;
        private float friction = 25;

        public PlayerStoppingState(PlayerController player)
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
            if(player.MovingDirection != 0)
            {
                player.ChangeState(new PlayerMovingState(player));
            }
            else
            {
                PhysicsController.ApplyFriction(player, friction);
                if (Mathf.Abs(player.rigidBody.velocity.x) < 0.001f)
                {
                    player.ChangeState(new PlayerIdleState(player));
                }
                if (player.Grounded == false)
                {
                    player.ChangeState(new PlayerOnAirState(player));
                }
            }
            
        }

        public void ExitPlayerState()
        {
            PhysicsController.SetVelocity(player, new Vector2(0, PhysicsController.GetVelocity(player).y));
        }
    }
}

