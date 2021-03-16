using Platformer.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Portal : MonoBehaviour
    {
        public bool portalAbbled = true;
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
            portalAbbled = true;
        }

        private void manageColliderTeleport(Collision2D collision)
        {
            KinematicObject kineObj = collision.gameObject.GetComponent<KinematicObject>();
            if (kineObj != null && portalAbbled)
            {
                partnerPortal.portalAbbled = false;
                portalAbbled = false;
                kineObj.transform.position = partnerPortal.transform.position;
            }
        }
    }
}

