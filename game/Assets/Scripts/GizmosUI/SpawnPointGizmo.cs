using UnityEngine;

namespace Platformer.GizmosUI
{
    /// <summary>
    /// Draws a back rectangle arround the SpawnPoint of the scene when selected in the editor
    /// </summary>
    public class SpawnPointGizmo : MonoBehaviour
    {
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(transform.position, new Vector3(0.8f, 0.8f, 0));
        }
    }
}

