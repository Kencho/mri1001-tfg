using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Physics;
using Platformer.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class KinematicObjectCollisionManager
    {
        private KinematicObject kineObj;
        private Vector2 lastDisabledMove;

        public KinematicObjectCollisionManager(KinematicObject kineObj)
        {
            this.kineObj = kineObj;
            lastDisabledMove = Vector2.zero;
        }

        public void manageCollision()
        {
            manageWallCollision();
        }

        public void manageWallCollision()
        {
            Vector2 velocity = PhisicsController.GetVelocity(kineObj);
            Bounds nextPlayerBounds = new Bounds(kineObj.mycollider.bounds.center, kineObj.mycollider.bounds.size);

            Vector2 nextPosition = (Vector2)nextPlayerBounds.center + (Time.fixedDeltaTime * velocity);
            nextPlayerBounds.center = nextPosition;

            GameObject wall = LayerContactChecker.GetContactLayerGameObject(nextPlayerBounds, "Wall");
            if(wall != null)
            {
                Collider2D wallCollider = wall.GetComponent<Collider2D>();
                Vector2 wallDirection = MathOperations.calculateDirection(kineObj.mycollider.bounds.center, wallCollider.ClosestPoint(kineObj.mycollider.bounds.center));
                if(lastDisabledMove != wallDirection)
                {
                    kineObj.EnableMove(lastDisabledMove);
                }
                KinematicObjectWallCollision ev = Simulation.Schedule<KinematicObjectWallCollision>();
                ev.kineObj = kineObj;
                ev.wallDirection = wallDirection;
                lastDisabledMove = wallDirection;
            }
            else
            {
                kineObj.EnableAllMove();
            }
            
        }
    }
}

