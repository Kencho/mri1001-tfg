using Platformer.Mechanics.KinematicObjects;
using Platformer.Mechanics.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    public class ImpulseAmplifier : ImpulseCreator
    {
        private float velocityScale;

        public ImpulseAmplifier(float velocityScale)
        {
            this.velocityScale = velocityScale;
        }

        public void ImpulseKinematicObject(KinematicObject kineObj)
        {
            Vector2 newVelocity = PhysicsController.GetVelocity(kineObj) * velocityScale;
            PhysicsController.SetVelocity(kineObj, newVelocity);
        }
    }
}

