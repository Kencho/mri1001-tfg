using Platformer.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    public class ImpulseParticle : ImpulseCreator
    {
        private Vector2 impulseAplied;

        public ImpulseParticle(Vector2 impulseAplied)
        {
            this.impulseAplied = impulseAplied;
        }

        public void ImpulseKinematicObject(KinematicObject kineObj)
        {
            PhisicsController.ApplyImpulse(kineObj, impulseAplied);
        }
    }
}

