using Platformer.Mechanics.Player.PlayerStates;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerMechanics
{
    /// <summary>
    /// Class that manages the Dash of the PlayerController
    /// </summary>
    public class Dash : PlayerMechanic
    {
        private float dashCooldown;
        private PlayerController player;
        private bool dashing;
        private bool dashAvailable;
        /// <summary>
        /// Counts how much seconds dash has been disabled
        /// </summary>
        private float timeWithoutDash;

        public bool Dashing { get => dashing;}

        public Dash(float dashCooldown, PlayerController player)
        {
            this.dashCooldown = dashCooldown;
            this.player = player;
            dashing = false;
            dashAvailable = true;
            timeWithoutDash = 0;
        }

        public void ManageFlags()
        {
            if(dashAvailable == false)
            {
                if (timeWithoutDash < dashCooldown)
                {
                    timeWithoutDash += Time.fixedDeltaTime;
                }
                else
                {
                    if (player.Grounded)
                    {
                        dashAvailable = true;
                    }
                }
            }
        }

        public void ManageInput()
        {
            if (Input.GetButton("Dash"))
            {
                dashing = true;
            }
            else
            {
                dashing = false;
            }
        }

        public void ExecuteMechanic()
        {
            if (dashing && dashAvailable)
            {
                ExecuteDash();
            }
        }

        private void ExecuteDash()
        {
            dashAvailable = false;
            timeWithoutDash = 0;
            player.ChangeState(new PlayerDashingState(player));
        }
    }
}

