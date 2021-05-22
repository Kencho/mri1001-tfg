using UnityEngine;

namespace Platformer.Mechanics.Enemies.ObstacleResources
{
    /// <summary>
    /// Class in charge of destroy Obstacle objects when they touch the collider associed to ObstacleDestroyer
    /// </summary>
    public class ObstacleDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Obstacle deletedObstacle = collision.gameObject.GetComponent<Obstacle>();

            if(deletedObstacle != null)
            {
                Destroy(deletedObstacle.gameObject);
            }
        }
    }
}

