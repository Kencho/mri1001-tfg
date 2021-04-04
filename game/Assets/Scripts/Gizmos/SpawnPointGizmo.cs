using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.GizmosUI
{
    public class SpawnPointGizmo : MonoBehaviour
    {
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(transform.position, new Vector3(0.8f, 0.8f, 0));
        }
    }
}

