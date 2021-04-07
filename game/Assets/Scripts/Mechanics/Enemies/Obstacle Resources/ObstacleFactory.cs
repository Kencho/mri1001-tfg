using Platformer.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemies
{
    public class ObstacleFactory : MonoBehaviour
    {
        public GameObject prefab;

        public void SpawnObject()
        {
            GameObject prefabInstance = Instantiate(prefab, transform.position, Quaternion.identity);
        }

    }
}

