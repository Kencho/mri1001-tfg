﻿using UnityEngine;

namespace Platformer.GizmosUI
{
    /// <summary>
    /// Draws a blue rectangle in the space occupied by the collider associed to the Wall when selected in the editor
    /// </summary>
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

}
