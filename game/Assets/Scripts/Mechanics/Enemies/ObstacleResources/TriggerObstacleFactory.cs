using Platformer.Mechanics.Resources;

namespace Platformer.Mechanics.Enemies.ObstacleResources
{
    /// <summary>
    /// Instantiates a Obstacle when PlayerController collides with the PlayerTrigger of the TriggerObstacleFactory
    /// </summary>
    public class TriggerObstacleFactory : ObstacleFactory
    {
        public PlayerTrigger trigger;
        private bool spawnable;

        /// <summary>
        /// check if the trigger is trigger and if is the case intantiates the Obstacle
        /// </summary>
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

