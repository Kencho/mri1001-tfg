using Platformer.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class GravityManager
    {
        private KinematicObject kineObj;
        private List<Vector2> gravityAltertions;

        public GravityManager(KinematicObject kineObj)
        {
            this.kineObj = kineObj;
            gravityAltertions = new List<Vector2>();
        }

        public void ManageGravity()
        {
            Vector2 gravityModifier = Vector2.zero;
            foreach(Vector2 gravityAltertion in gravityAltertions)
            {
                gravityModifier += gravityAltertion;
            }
            PhisicsController.SimulateGarvity(kineObj, gravityModifier);
            gravityAltertions = new List<Vector2>();
        }

        public void addGravityAlteration(Vector2 gravityAlteration)
        {
            gravityAltertions.Add(gravityAlteration);
        }
    }
}

