using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerMechanics
{
    public class BulletTime : PlayerMechanic
    {
        private float bulletTimeCooldonw;
        private float bulletTimeDuration;
        private float timeScale;
        private PlayerController player;
        private float timeWithoutBulletTime;
        private bool bulletTimeAvailable;
        private bool bulletTimeActive;

        public bool BulletTimeActive { get => bulletTimeActive;}

        public BulletTime(float bulletTimeCooldonw, float bulletTimeDuration, float timeScale, PlayerController player)
        {
            this.bulletTimeCooldonw = bulletTimeCooldonw;
            this.bulletTimeDuration = bulletTimeDuration;
            this.player = player;
            this.timeScale = timeScale;
            timeWithoutBulletTime = 0;
            bulletTimeAvailable = true;
            bulletTimeActive = false;
        }

        public void ManageFlags()
        {
            if (bulletTimeAvailable == false)
            {
                if (timeWithoutBulletTime < bulletTimeCooldonw)
                {
                    timeWithoutBulletTime += Time.fixedDeltaTime;
                }
                else
                {
                    bulletTimeAvailable = true;
                    timeWithoutBulletTime = 0;
                }
            }
        }

        public void ManageInput()
        {
            if (Input.GetButton("BulletTime"))
            {
                bulletTimeActive = true;
            }
            else
            {
                bulletTimeActive = false;
            }
        }

        public void ExecuteMechanic()
        {
            if (bulletTimeActive && bulletTimeAvailable)
            {
                ExecuteBulletTime();
            }
        }

        private void ExecuteBulletTime()
        {
            PlatformerModel.timeManager.ScaleGlobalTime(timeScale, bulletTimeDuration);
            bulletTimeAvailable = false;
        }
    }
}

