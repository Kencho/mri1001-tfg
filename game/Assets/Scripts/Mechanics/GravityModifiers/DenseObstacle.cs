using Platformer.Mechanics.KinematicObjects;
using UnityEngine;

namespace Platformer.Mechanics.GravityModifiers
{
    /// <summary>
    /// StatiC Obstacle that attracts KinematicObjects to him
    /// </summary>
    public class DenseObstacle : MonoBehaviour
    {
        /// <summary>
        /// Value used to calculate the force of attraction depending of the distance to DenseObstacle
        /// </summary>
        public float gravityInfluence;
        /// <summary>
        /// Max force that will be applied to attract KinameticObjects
        /// </summary>
        public float maxInfluence;

        /// <summary>
        /// Method that attracts KinematicObjects to the DenseObstacle
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerStay2D(Collider2D collision)
        {
            KinematicObject kineObj = collision.gameObject.GetComponent<KinematicObject>();

            if(kineObj != null)
            {
                Vector2 kineObjDistance = CalculateKinematicObjectDirection(kineObj);
                kineObj.ApplyGravityAlteration(kineObjDistance * -gravityInfluence + kineObjDistance * maxInfluence);
            }
        }

        /// <summary>
        /// Calculates the directión of the KinematicObject taking as reference DenseObstacle
        /// </summary>
        /// <param name="kineObj"></param>
        /// <returns>Direction of the the KinematicObjects</returns>
        private Vector2 CalculateKinematicObjectDirection(KinematicObject kineObj)
        {
            return (this.transform.position - kineObj.transform.position).normalized;
        }
    }

}
