using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics.Enemies.ObstacleResources
{
    public class ObstacleFactory : MonoBehaviour
    {
        public GameObject prefab;

        public void SpawnObject()
        {
            GameObject prefabInstance = Instantiate(prefab, transform.position, Quaternion.identity);

            PlatformerModel.gameController.AddInstancedObject(prefabInstance);
    }

    }
}

