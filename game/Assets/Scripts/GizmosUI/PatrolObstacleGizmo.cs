using Platformer.Mechanics.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.GizmosUI
{
    public class PatrolObstacleGizmo : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            PatrolObstacle obstacle = gameObject.GetComponent<PatrolObstacle>();

            if(obstacle != null)
            {
                List<Vector2> travelPath = obstacle.travelPath;
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
}

