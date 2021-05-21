using Platformer.Core;
using UnityEngine;
using Platformer.Physics;
using Platformer.Mechanics.Player.PlayerStates;
using Platformer.Mechanics.Player;

namespace Platformer.Gameplay.PlayerEvents
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
            if (player.audioSource && player.jumpAudio)
                player.audioSource.PlayOneShot(player.jumpAudio);
            player.ChangeState(new PlayerOnAirState(player));
        }
    }
}