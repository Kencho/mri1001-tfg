using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Physics;
using System;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    public class KinematicObjectWallCollision : Simulation.Event<KinematicObjectWallCollision>
    {
        public KinematicObject kineObj;
        public Vector2 wallDirection;

        public override void Execute()
        {
            kineObj.disableMove(wallDirection);
            PhisicsController.SetVelocityWithRestrictions(kineObj, PhisicsController.GetVelocity(kineObj));
        }

        private Vector2 UpdadeVelocityKinObj()
        {
            Vector2 newVelocity = PhisicsController.GetVelocity(kineObj);

            if(wallDirection.x != 0)
            {
                newVelocity.x = 0;
            }

            if(wallDirection.y != 0){
                newVelocity.y = 0;
            }

            return newVelocity;
        }
    }

}

