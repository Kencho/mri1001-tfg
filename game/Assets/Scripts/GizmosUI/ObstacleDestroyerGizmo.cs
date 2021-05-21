using UnityEngine;

namespace Platformer.GizmosUI
{
    public class ObstacleDestroyerGizmo : MonoBehaviour
    {
        private void OnDrawGizmosSelected()
        {
            Bounds destroyerCollider = gameObject.GetComponent<Collider2D>().bounds;

            if (destroyerCollider != null)
            {
                Gizmos.color = new Vector4(0, 1, 1, 0.5f); //cyan
                Gizmos.DrawCube(destroyerCollider.center, 2 * destroyerCollider.extents);
            }
        }
    }
}

