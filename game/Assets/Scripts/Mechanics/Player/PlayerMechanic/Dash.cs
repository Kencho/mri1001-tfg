using Platformer.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerMechanics
{
    public class Dash : PlayerMechanic
    {
        private float dashCooldown;
        private PlayerController player;
        private bool dashing;
        private bool dashAvailable;
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

