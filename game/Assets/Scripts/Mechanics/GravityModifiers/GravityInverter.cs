using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class GravityInverter : MonoBehaviour
    {
        public GravityInverterManager gravityInverterManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            KinematicObject kineObj = collision.gameObject.GetComponent<KinematicObject>();
            if (kineObj != null)
            {
                InverGravityOfKinematicObject(kineObj);
                kineObj.transform.Rotate(new Vector3(180, 0, 0));
            }
        }

        private void InverGravityOfKinematicObject(KinematicObject kineObj)
        {
            gravityInverterManager.InverGravityOfKinematicObject(kineObj);
        }
    }
}


