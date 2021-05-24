using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    /// <summary>
    /// ImpulseCreatorCollider with a impulseCreator of the type ImpulseParticle
    /// </summary>
    public class ImpulseParticleCollider : ImpulseCreatorCollider
    {
        public Vector2 impulseAplied;

        protected override void SetImpulseCreator()
        {
            impulseCreator = new ImpulseParticle(impulseAplied);
        }
    }
}

