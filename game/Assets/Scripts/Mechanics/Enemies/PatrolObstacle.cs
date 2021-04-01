using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemies
{
    public class PatrolObstacle : Obstacle
    {
        public List<Vector2> travelPath;
        public float pathTimeTravel; //in seconds
        private PatrolPath path;

        private void Start()
        {
            path = new PatrolPath(travelPath, pathTimeTravel);
            transform.position = travelPath[0];
        }

        private void Update()
        {
            transform.position = path.getNextPathPosition();
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < travelPath.Count; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(travelPath[i], 0.2f);
                Gizmos.color = Color.green;
                Gizmos.DrawLine(travelPath[i], travelPath[(i + 1) % travelPath.Count]);
            }
        }
    }
}

