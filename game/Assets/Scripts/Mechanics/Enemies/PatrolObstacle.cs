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
    }
}

