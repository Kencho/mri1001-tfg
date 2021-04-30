using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class ImpulseParticleCollider : ImpulseCreatorCollider
    {
        public Vector2 impulseAplied;

        protected override void SetImpulseCreator()
        {
            impulseCreator = new ImpulseParticle(impulseAplied);
        }
    }
}

