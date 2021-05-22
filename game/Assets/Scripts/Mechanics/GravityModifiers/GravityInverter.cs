using Platformer.Mechanics.KinematicObjects;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics.GravityModifiers
{
    /// <summary>
    /// Class that invert the gravity of the KinematicObjects that collides with him
    /// </summary>
    public class GravityInverter : MonoBehaviour
    {
        /// <summary>
        /// Class wich modify gravity of the KinematicObjects
        /// </summary>
        private GravityInverterManager gravityInverterManager;

        /// <summary>
        /// Check if a KinematicObject is in collision whit the GravityInverter and inverts KinematicObject´s gravity if that is the case 
        /// </summary>
        /// <param name="collision"></param>
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


