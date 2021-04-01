using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemies
{
    public class MovingObstacle : Obstacle
    {
        public float speed = 5f;

        private void FixedUpdate()
        {
            this.transform.position += (Vector3) Vector2.left * speed * Time.fixedDeltaTime;
        }
    }
}

