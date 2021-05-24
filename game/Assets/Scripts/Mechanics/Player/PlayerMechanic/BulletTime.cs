using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics.Player.PlayerMechanics
{
    /// <summary>
    /// Class that manages the bullet time mechanic of the PlayerController
    /// </summary>
    public class BulletTime : PlayerMechanic
    {
        private float bulletTimeCooldown;
        /// <summary>
        /// How much secons bullet time is applied
        /// </summary>
        private float bulletTimeDuration;
        /// <summary>
        /// time scale that applies bullet time
        /// </summary>
        private float timeScale;
        private PlayerController player;
        /// <summary>
        /// Seconds that has passed with bullet time disabled
        /// </summary>
        private float timeWithoutBulletTime;
        private bool bulletTimeAvailable;
        private bool bulletTimeActive;

        public bool BulletTimeActive { get => bulletTimeActive;}

        public BulletTime(float bulletTimeCooldown, float bulletTimeDuration, float timeScale, PlayerController player)
        {
            this.bulletTimeCooldown = bulletTimeCooldown;
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
                if (timeWithoutBulletTime < bulletTimeCooldown)
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

