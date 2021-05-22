using Platformer.Mechanics.KinematicObjects;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Class that teleports KinematicObjects to other portal
    /// </summary>
    public class Portal : MonoBehaviour
    {
        public bool portalEnabled = true;
        /// <summary>
        /// Portal where the KinematicObjects will be teleported
        /// </summary>
        public Portal partnerPortal;
        private Collider2D portalCollider;

        private void Awake()
        {
            portalCollider = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            manageColliderTeleport(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            portalEnabled = true;
        }

        /// <summary>
        /// Teleport KinematicObjects if entered in contact with the portal
        /// </summary>
        /// <param name="collision"></param>
        private void manageColliderTeleport(Collision2D collision)
        {
            KinematicObject kineObj = collision.gameObject.GetComponent<KinematicObject>();
            if (kineObj != null && portalEnabled)
            {
                partnerPortal.portalEnabled = false;
                portalEnabled = false;
                kineObj.transform.position = partnerPortal.transform.position;
            }
        }
    }
}

