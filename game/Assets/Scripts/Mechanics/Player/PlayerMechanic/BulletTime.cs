using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Player
{
    public class BulletTime : PlayerMechanic
    {
        private float bulletTimeColdonw;
        private float bulletTimeDuration;
        private float timeScale;
        private PlayerController player;
        private float timeWithOutBulletTime;
        private bool bulletTimeAbble;
        private bool applingBulletTime;

        public bool ApplingBulletTime { get => applingBulletTime;}

        public BulletTime(float bulletTimeColdonw, float bulletTimeDuration, float timeScale, PlayerController player)
        {
            this.bulletTimeColdonw = bulletTimeColdonw;
            this.bulletTimeDuration = bulletTimeDuration;
            this.player = player;
            this.timeScale = timeScale;
            timeWithOutBulletTime = 0;
            bulletTimeAbble = true;
            applingBulletTime = false;
        }

        public void ManageFlags()
        {
            if (bulletTimeAbble == false)
            {
                if (timeWithOutBulletTime < bulletTimeColdonw)
                {
                    timeWithOutBulletTime += Time.fixedDeltaTime;
                }
                else
                {
                    bulletTimeAbble = true;
                    timeWithOutBulletTime = 0;
                }
            }
        }

        public void ManageInput()
        {
            if (Input.GetButton("BulletTime"))
            {
                applingBulletTime = true;
            }
            else
            {
                applingBulletTime = false;
            }
        }

        public void ExecuteMechanic()
        {
            if (applingBulletTime && bulletTimeAbble)
            {
                ExecuteBulletTime();
            }
        }

        private void ExecuteBulletTime()
        {
            PlatformerModel.timeManager.ScaleGlobalTime(timeScale, bulletTimeDuration);
            bulletTimeAbble = false;
        }
    }
}

