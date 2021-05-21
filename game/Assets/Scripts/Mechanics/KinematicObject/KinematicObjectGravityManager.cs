using Platformer.Mechanics.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.KinematicObjects
{
    public class KinematicObjectGravityManager
    {
        private KinematicObject kineObj;
        private List<Vector2> gravityAlterations;

        public KinematicObjectGravityManager(KinematicObject kineObj)
        {
            this.kineObj = kineObj;
            gravityAlterations = new List<Vector2>();
        }

        public void HandleGravity()
        {
            Vector2 aggregatedGravityModifier = Vector2.zero;
            foreach(Vector2 gravityAlteration in gravityAlterations)
            {
                aggregatedGravityModifier += gravityAlteration;
            }
            PhysicsController.SimulateGravity(kineObj, aggregatedGravityModifier);
            gravityAlterations = new List<Vector2>();
        }

        public void AddGravityAlteration(Vector2 gravityAlteration)
        {
            gravityAlterations.Add(gravityAlteration);
        }
    }
}

