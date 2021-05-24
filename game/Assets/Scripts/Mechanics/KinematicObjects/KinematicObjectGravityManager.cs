using Platformer.Mechanics.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.KinematicObjects
{
    /// <summary>
    /// Class in charge of manage the gravity alterarions of the KinematicObject
    /// </summary>
    public class KinematicObjectGravityManager
    {
        private KinematicObject kineObj;
        /// <summary>
        /// List of gravity alterations that will be aplied each call of the FixedUpdate loop
        /// </summary>
        private List<Vector2> gravityAlterations;

        public KinematicObjectGravityManager(KinematicObject kineObj)
        {
            this.kineObj = kineObj;
            gravityAlterations = new List<Vector2>();
        }

        /// <summary>
        /// Method that aplies all the gravity alterations to the KinematicObject
        /// </summary>
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

