using Platformer.Mechanics.Resources;

namespace Platformer.Mechanics.Enemies.ObstacleResources
{
    public class TriggerObstacleFactory : ObstacleFactory
    {
        public PlayerTrigger trigger;
        private bool spawnable;

        private void Update()
        {
            if (trigger.IsTriggered)
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

