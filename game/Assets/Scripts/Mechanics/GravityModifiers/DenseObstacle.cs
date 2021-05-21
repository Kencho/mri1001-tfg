using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.GravityModifiers
{
    public class DenseObstacle : MonoBehaviour
    {
        public float gravityInfluence;
        public float maxInfluence;

        private void OnTriggerStay2D(Collider2D collision)
        {
            KinematicObject kineObj = collision.gameObject.GetComponent<KinematicObject>();

            if(kineObj != null)
            {
                Vector2 kineObjDistance = CalculateKinematicObjectDirection(kineObj);
                kineObj.ApplyGravityAlteration(kineObjDistance * -gravityInfluence + kineObjDistance * maxInfluence);
            }
        }

        private Vector2 CalculateKinematicObjectDirection(KinematicObject kineObj)
        {
            return (this.transform.position - kineObj.transform.position).normalized;
        }
    }

}
