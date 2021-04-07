using Platformer.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemies
{
    public class TriggerObstacleFactory : ObstacleFactory
    {
        public PlayerTrigger trigger;
        private bool spawnable;

        private void Update()
        {
            if (trigger.IsTrigger)
            {
                if (spawnable)
                {
                    SpawnObject();
                }
                spawnable = false;
            }
            else
            {
                spawnable = true;
            }
        }
    }
}

