using Platformer.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
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
            Vector2 newVelocity = PhisicsController.GetVelocity(kineObj) * velocityScale;
            PhisicsController.SetVelocity(kineObj, newVelocity);
        }
    }
}

