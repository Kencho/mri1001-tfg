using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics.Enemies.ObstacleResources
{
    /// <summary>
    /// Class that instantiates Obstacles accord to factory method design pattern
    /// </summary>
    public class ObstacleFactory : MonoBehaviour
    {
        /// <summary>
        /// Obstacle prefab used to instantiate Obstacles
        /// </summary>
        public GameObject prefab;

        public void SpawnObject()
        {
            GameObject prefabInstance = Instantiate(prefab, transform.position, Quaternion.identity);

            PlatformerModel.gameController.AddInstancedObject(prefabInstance);
    }

    }
}

