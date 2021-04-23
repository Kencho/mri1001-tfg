using Platformer.Core;
using UnityEngine;
using Platformer.Physics;
using Platformer.Player;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player performs a Jump.
    /// </summary>
    /// <typeparam name="PlayerJumped"></typeparam>
    public class PlayerJumped : Simulation.Event<PlayerJumped>
    {
        public PlayerController player;

        public override void Execute()
        {
            PhisicsController.ApplyImpulse(player, Vector2.up * player.jumpImpulse);
            MonoBehaviour.print(PhisicsController.GetVelocity(player));
            if (player.audioSource && player.jumpAudio)
                player.audioSource.PlayOneShot(player.jumpAudio);
            player.playerState = new PlayerOnAirState(player);
        }
    }
}