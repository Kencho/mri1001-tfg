using Platformer.Mechanics.KinematicObjects;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.Player.PlayerStates;
using Platformer.Mechanics.Resources;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    /// <summary>
    /// Impulse creator that applies a multiplier to KinematicObject´s velocity
    /// </summary>
    public class ImpulseAmplifier : ImpulseCreator
    {
        /// <summary>
        /// Multipier applier to KinematicObject´s velocity
        /// </summary>
        private float velocityScale;

        public ImpulseAmplifier(float velocityScale)
        {
            this.velocityScale = velocityScale;
        }

        public void ImpulseKinematicObject(KinematicObject kineObj)
        {
            Vector2 newVelocity = PhysicsController.GetVelocity(kineObj) * velocityScale;
            PhysicsController.SetVelocity(kineObj, Vector2.zero);
            PhysicsController.SetVelocity(kineObj, newVelocity);
            if (kineObj.GetType() == typeof(PlayerController))
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

