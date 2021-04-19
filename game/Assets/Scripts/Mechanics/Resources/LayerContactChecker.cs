﻿using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Resources
{
    public class LayerContactChecker
    {
        public static bool IsInContactWithLayer(KinematicObject kinematicObj, string layerName, float extraHeigh = 0.05f)
        {
            LayerMask layer = LayerMask.GetMask(layerName);
            return IsInContactWithLayer(kinematicObj.mycollider.bounds, layerName);
        }

        public static bool IsInContactWithLayer(Bounds bounds, string layerName, float extraHeigh = 0.05f)
        {
            LayerMask layer = LayerMask.GetMask(layerName);
            RaycastHit2D raycastHit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, extraHeigh, layer);

            if (raycastHit.collider == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static GameObject GetContactLayerGameObject(Bounds bounds, string layerName, float extraHeigh = 0.05f)
        {
            LayerMask layer = LayerMask.GetMask(layerName);
            RaycastHit2D raycastHit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, extraHeigh, layer);

            if (raycastHit.collider == null)
            {
                return null;
            }
            else
            {
                return raycastHit.collider.gameObject;
            }
        }
    }
}
