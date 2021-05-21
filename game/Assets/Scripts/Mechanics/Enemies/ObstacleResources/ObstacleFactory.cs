using Platformer.Animation;
using Platformer.Core;
using Platformer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
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

