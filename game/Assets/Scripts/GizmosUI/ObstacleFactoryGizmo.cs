using Platformer.Mechanics.Enemies.ObstacleResources;
using UnityEngine;

namespace Platformer.GizmosUI
{
    public class ObstacleFactoryGizmo : MonoBehaviour
    {
        /// <summary>
        /// Draws a green sphere in the positión where the ObstacleFactory is located in the editor
        /// </summary>
        private void OnDrawGizmos()
        {
            Vector2 fabricPosition = gameObject.GetComponent<TriggerObstacleFactory>().transform.position;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(fabricPosition, 0.35f);
        }

        /// <summary>
        /// Draws a blue rectangle in the space occupied by the trigger associated to the ObstacleFabric in the fabric when the ObstacleFabric is
        /// selected in the editor
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Bounds triggerZone = gameObject.GetComponent<TriggerObstacleFactory>().trigger.GetComponent<Collider2D>().bounds;

            Gizmos.color = new Vector4(0, 0, 1, 0.5f);
            Gizmos.DrawCube(triggerZone.center, 2 * triggerZone.extents);
        }
    }
}

