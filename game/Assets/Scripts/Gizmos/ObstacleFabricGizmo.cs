using Platformer.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.GizmosUI
{
    public class ObstacleFabricGizmo : MonoBehaviour
    {

        private void OnDrawGizmos()
        {
            Vector2 fabricPosition = gameObject.GetComponent<TriggerObstacleFabric>().transform.position;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(fabricPosition, 0.35f);
        }

        private void OnDrawGizmosSelected()
        {
            Bounds triggerZone = gameObject.GetComponent<TriggerObstacleFabric>().trigger.GetComponent<Collider2D>().bounds;

            Gizmos.color = new Vector4(0, 0, 1, 0.5f);
            Gizmos.DrawCube(triggerZone.center, 2 * triggerZone.extents);
        }
    }
}

