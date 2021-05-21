using Platformer.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerMechanics
{
    public class Dash : PlayerMechanic
    {
        private float dashColdown;
        private PlayerController player;
        private bool dashing;
        private bool dashable;
        private float timeWithOutFlash;

        public bool Dashing { get => dashing;}

        public Dash(float dashColdown, PlayerController player)
        {
            this.dashColdown = dashColdown;
            this.player = player;
            dashing = false;
            dashable = true;
            timeWithOutFlash = 0;
        }

        public void ManageFlags()
        {
            if(dashable == false)
            {
                if (timeWithOutFlash < dashColdown)
                {
                    timeWithOutFlash += Time.fixedDeltaTime;
                }
                else
                {
                    if (player.Grounded)
                    {
                        dashable = true;
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
            if (dashing & dashable)
            {
                ExecuteDash();
            }
        }

        private void ExecuteDash()
        {
            dashable = false;
            timeWithOutFlash = 0;
            player.ChangeState(new PlayerDashingState(player));
        }
    }
}

