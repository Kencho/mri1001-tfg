using UnityEngine;

namespace Platformer.Mechanics.Enemies
{
    /// <summary>
    /// Obstacle that moves from left to right at a constant speed
    /// </summary>
    public class MovingObstacle : Obstacle
    {
        public float speed = 5f;

        /// <summary>
        /// Performs the movement accord of being a TimeAffectedObject
        /// </summary>
        protected override void Move()
        {
            Vector3 traveledDistance = (Vector3)Vector2.left * speed * Time.fixedDeltaTime;
            Vector3 timeAfectedTraveledDistance = traveledDistance * TimeScale;
            transform.position += timeAfectedTraveledDistance;
        }
    }
}

