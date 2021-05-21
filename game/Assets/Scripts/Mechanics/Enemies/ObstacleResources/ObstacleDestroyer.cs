using UnityEngine;

namespace Platformer.Mechanics.Enemies.ObstacleResources
{
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

