using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
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

