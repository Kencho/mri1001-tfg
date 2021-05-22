using Platformer.Mechanics.KinematicObjects;
using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    /// <summary>
    /// Impulse creator that impulses KinematicObjects in a direction
    /// </summary>
    public class ImpulseParticle : ImpulseCreator
    {
        /// <summary>
        /// Direction of the impulse applied to de KinematicObjets
        /// </summary>
        private Vector2 impulseAplied;

        public ImpulseParticle(Vector2 impulseAplied)
        {
            this.impulseAplied = impulseAplied;
        }

        public void ImpulseKinematicObject(KinematicObject kineObj)
        {
            PhysicsController.ApplyImpulse(kineObj, impulseAplied);
        }
    }
}

