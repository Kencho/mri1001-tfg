using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics.ImpulseCreators;
using Platformer.Physics;
using Platformer.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.KinematicObjects
{
    public class KinematicObjectCollisionManager
    {
        private KinematicObject kineObj;

        public KinematicObjectCollisionManager(KinematicObject kineObj)
        {
            this.kineObj = kineObj;
        }

        public void manageCollision()
        {
            manageWallCollision();
            manageImpulseCreatorCollision();
        }

        public void manageWallCollision()
        {
            Vector2 velocity = PhisicsController.GetVelocity(kineObj);
            LayerMask layer = LayerMask.GetMask("Wall");

            RaycastHit2D[] wall_collision = Physics2D.BoxCastAll(kineObj.mycollider.bounds.center, 2*kineObj.mycollider.bounds.extents, 0f, velocity.normalized, 0, layer);
            for(int i = 0; i < wall_collision.Length; i++)
            {
                RaycastHit2D wall = wall_collision[i];
                if(wall.normal.x == 1)
                {
                    if(velocity.x < 0)
                    {
                        PhisicsController.SetVelocity(kineObj, new Vector2(0, PhisicsController.GetVelocity(kineObj).y));
                    }
                }else if (wall.normal.x == -1)
                {
                    if(velocity.x > 0)
                    {
                        PhisicsController.SetVelocity(kineObj, new Vector2(0, PhisicsController.GetVelocity(kineObj).y));
                    }
                }

                if (wall.normal.y == 1)
                {
                    if (velocity.y < 0)
                    {
                        PhisicsController.SetVelocity(kineObj, new Vector2(PhisicsController.GetVelocity(kineObj).x, 0));
                    }
                }
                else if (wall.normal.y == -1)
                {
                    if (velocity.y > 0)
                    {
                        PhisicsController.SetVelocity(kineObj, new Vector2(PhisicsController.GetVelocity(kineObj).x, 0));
                    }
                }

            }
        }

        private void manageImpulseCreatorCollision()
        {
            Vector2 velocity = PhisicsController.GetVelocity(kineObj);
            LayerMask layer = LayerMask.GetMask("ImpulseCreator");

            RaycastHit2D[] impulseCreatorCollision = Physics2D.BoxCastAll(kineObj.mycollider.bounds.center, 2 * kineObj.mycollider.bounds.extents, 0f, velocity.normalized, 0, layer);
            for (int i = 0; i < impulseCreatorCollision.Length; i++)
            {
                ImpulseCreatorCollider impulseCreator = impulseCreatorCollision[i].collider.GetComponent<ImpulseCreatorCollider>();
                impulseCreator.ApplyKinematicObjectCollision(kineObj);
                
            }
        }
    }
}

