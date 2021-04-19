using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Resources
{
    public class MathOperations
    {
        public static float getEuclideanDistance(Vector2 vector1, Vector2 vector2)
        {
            return Mathf.Sqrt(Mathf.Pow((vector2.x - vector1.x), 2) + Mathf.Pow((vector2.y - vector1.y), 2));
        }

        public static Vector2 calculateDirection(Vector2 from, Vector2 to)
        {
            Vector2 wallDirection = Vector2.zero;
            Vector2 wallDistance = (to - (Vector2) from);

            if (wallDistance.x > 0.01f)
            {
                wallDirection.x = 1;
            }
            else if(wallDistance.x < -0.01f)
            {
                wallDirection.x = -1;
            }

            if (wallDistance.y > 0.01f)
            {
                wallDirection.y = 1;
            }
            else if(wallDistance.y < -0.01f)
            {
                wallDirection.y = -1;
            }

            return wallDirection;
        }
    }
}

