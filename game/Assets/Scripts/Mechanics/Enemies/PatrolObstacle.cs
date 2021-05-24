using Platformer.Mechanics.PatrolPath;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.Enemies
{
    /// <summary>
    /// Obstacle that follows a path determined by points ad infinitum
    /// </summary>
    public class PatrolObstacle : Obstacle
    {
        /// <summary>
        /// List of the points that the PatrolObstacle will travel
        /// </summary>
        public List<Vector2> travelPath;
        /// <summary>
        /// Seconds that the travel will last 
        /// </summary>
        public float travelDuration; 
        /// <summary>
        /// Object that will calculate the next of the PatrolObstacle
        /// </summary>
        private TimeAffectedPatrolPath path;

        private void Start()
        {
            path = new TimeAffectedPatrolPath(travelPath, travelDuration);
            transform.position = travelPath[0];
        }

        /// <summary>
        /// Performs the movement accord of being a TimeAffectedObject
        /// </summary>
        protected override void Move()
        {
            transform.position = path.GetNextPathPosition();
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

