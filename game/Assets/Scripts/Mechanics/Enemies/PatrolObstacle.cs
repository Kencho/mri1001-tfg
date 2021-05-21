using Platformer.Mechanics;
using Platformer.Mechanics.PatrolPath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.Enemies
{
    public class PatrolObstacle : Obstacle
    {
        public List<Vector2> travelPath;
        public float travelDuration; //in seconds
        private TimeAfectedPatrolPath path;

        private void Start()
        {
            path = new TimeAfectedPatrolPath(travelPath, travelDuration);
            transform.position = travelPath[0];
        }

        protected override void Move()
        {
            transform.position = path.getNextPathPosition();
        }

        public override void SetTimeScale(float timeScale)
        {
            base.SetTimeScale(timeScale);
            path.ScaleTime(timeScale);
        }

        public override void ResetTimeScale()
        {
            base.ResetTimeScale();
            path.UnScaleTime();
        }
    }
}

