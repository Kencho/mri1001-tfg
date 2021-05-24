using Platformer.Mechanics.KinematicObjects;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.Player.PlayerStates;
using Platformer.Mechanics.Resources;
using Platformer.Model;
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
            PhysicsController.SetVelocity(kineObj, Vector2.zero);
            PhysicsController.ApplyImpulse(kineObj, impulseAplied);
            if(kineObj.GetType() == typeof(PlayerController))
            {
                ChangePlayerState();
            }
        }

        private void ChangePlayerState()
        {
            PlayerController player = PlatformerModel.player;
            player.ChangeState(new PlayerIdleState(player));
        }
    }
}

