using System;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Physics;
using UnityEngine;

namespace Platformer.Player
{
    public class Jump : PlayerMechanic
    {
        private float jumpImpulse;
        private float jumpForceApplied;
        private bool jumping;
        private bool jumpable;
        private PlayerController player;
        private Vector2 vectorDirection;

        public bool Jumping { get => jumping;}

        public Jump(float jumpImpulse, Vector2 vectorDirection, PlayerController player)
        {
            this.jumpImpulse = jumpImpulse;
            this.vectorDirection = vectorDirection;
            this.player = player;
            jumpable = true;
        }

        public void ManageFlags()
        {
            if (player.Grounded)
            {
                jumpable = true;
            }
            else
            {
                jumpable = false;
            }
        }

        public void ManageInput()
        {
            if(jumpable == true)
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

        private void ExecuteJump()
        {
            jumpable = false;
            Vector2 jumpForce = vectorDirection * jumpImpulse;
            Vector2 forceApplied = PhisicsController.ApplyImpulse(player, jumpForce);
            jumpForceApplied += forceApplied.magnitude;
            PlayerJumped ev = Simulation.Schedule<PlayerJumped>();
            ev.player = player;
            if(jumpForceApplied >= jumpImpulse)
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

