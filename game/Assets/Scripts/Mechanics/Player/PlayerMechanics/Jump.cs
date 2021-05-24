using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerMechanics
{
    /// <summary>
    /// Class that manages the jump of the PlayerController
    /// </summary>
    public class Jump : PlayerMechanic
    {
        /// <summary>
        /// Total impulse applied when jumping
        /// </summary>
        private float jumpImpulse;
        /// <summary>
        /// Current impulse aplied during jumping
        /// </summary>
        private float jumpForceApplied;
        private bool jumping;
        private bool jumpAvailable;
        private PlayerController player;
        /// <summary>
        /// Direction of the jump
        /// </summary>
        private Vector2 vectorDirection;

        public bool Jumping { get => jumping;}

        public Jump(float jumpImpulse, Vector2 vectorDirection, PlayerController player)
        {
            this.jumpImpulse = jumpImpulse;
            this.vectorDirection = vectorDirection;
            this.player = player;
            jumpAvailable = true;
        }

        public void ManageFlags()
        {
            if (player.Grounded)
            {
                jumpAvailable = true;
            }
            else
            {
                jumpAvailable = false;
            }
        }

        public void ManageInput()
        {
            if(jumpAvailable == true)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    jumping = true;
                }
            }
            
        }

        public void ExecuteMechanic()
        {
            if(jumping)
            {
                ExecuteJump();
            }
        }

        /// <summary>
        /// Execute all the instructions needed to perform jump on each loop of FixedUpdate
        /// </summary>
        private void ExecuteJump()
        {
            jumpAvailable = false;
            Vector2 jumpForce = vectorDirection * jumpImpulse;
            Vector2 forceApplied = PhysicsController.ApplyImpulse(player, jumpForce);
            jumpForceApplied += forceApplied.magnitude * player.TimeScale;
            PlayerJumped ev = Simulation.Schedule<PlayerJumped>();
            ev.player = player;
            if (jumpForceApplied >= jumpImpulse)
            {
                ResetJump();
            }
        }

        private void ResetJump()
        {
            jumping = false;
            jumpForceApplied = 0;
        }
    }
}

