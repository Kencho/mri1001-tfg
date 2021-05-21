using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGizmo : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Bounds wall_collider = GetComponent<Collider2D>().bounds;

        if (wall_collider != null)
        {
            Gizmos.color = new Vector4(0, 0, 1, 0.6f);
            Gizmos.DrawCube(wall_collider.center, 2 * wall_collider.extents);
        }
    }
}
