using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class LayerContactChecker
    {
        public static bool IsInContactWithLayer(KinematicObject kinematicObj, string layerName, float extraHeigh = 0.05f)
        {
            LayerMask layer = LayerMask.GetMask(layerName);
            RaycastHit2D raycastHit = Physics2D.BoxCast(kinematicObj.mycollider.bounds.center, kinematicObj.mycollider.bounds.size, 0f, Vector2.down, extraHeigh, layer);

            if(raycastHit.collider == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
