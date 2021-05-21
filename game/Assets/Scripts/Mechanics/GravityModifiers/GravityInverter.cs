using Platformer.Mechanics.KinematicObjects;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics.GravityModifiers
{
    public class GravityInverter : MonoBehaviour
    {
        private GravityInverterManager gravityInverterManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            KinematicObject kineObj = collision.gameObject.GetComponent<KinematicObject>();
            if (kineObj != null)
            {
                gravityInverterManager = PlatformerModel.gravityInverterManager;
                InverGravityOfKinematicObject(kineObj);
                kineObj.transform.Rotate(new Vector3(180, 0, 0));
            }
        }

        private void InverGravityOfKinematicObject(KinematicObject kineObj)
        {
            gravityInverterManager.InvertGravityOfKinematicObject(kineObj);
        }
    }
}


