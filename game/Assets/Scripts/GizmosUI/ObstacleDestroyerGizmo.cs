using UnityEngine;

namespace Platformer.GizmosUI
{
    /// <summary>
    /// Class that draws a cyan rectangle in the space occupied by ObstacleDestroyer component of the GameObject in the editor
    /// </summary>
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

