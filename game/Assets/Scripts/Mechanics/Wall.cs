using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay;

namespace Platformer.Prueba
{
    public class Wall : MonoBehaviour
    {
        public Collider2D wallCollider;

        private void Awake()
        {
            wallCollider = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            KinematicObject kineObj = collision.gameObject.GetComponent<KinematicObject>();

            if(kineObj != null)
            {
                KinematicObjectWallCollision ev = Simulation.Schedule<KinematicObjectWallCollision>();
                ev.kineObj = kineObj;
                ev.wallDirection = calculateWallDirection(collision, kineObj);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.EnableAllMove();
            }
        }

        private Vector2 calculateWallDirection(Collision2D collision, KinematicObject kineObj)
        {
            Vector2 wallNearestPoint = wallCollider.ClosestPoint(kineObj.mycollider.bounds.center);
            Vector2 wallDirection = Vector2.zero;
            Vector2 wallDistance = (wallNearestPoint - (Vector2) kineObj.mycollider.bounds.center);

            if (wallDistance.x > 0.01f)
            {
                wallDirection.x = 1;
            }
            else if(wallDistance.x < -0.01f)
            {
                wallDirection.x = -1;
            }

            if (wallDistance.y > 0.01f)
            {
                wallDirection.y = 1;
            }
            else if(wallDistance.y < -0.01f)
            {
                wallDirection.y = -1;
            }

            return wallDirection;
        }
    }
}

