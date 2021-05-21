using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.Resources;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay.PlayerEvents
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {

        public override void Execute()
        {
            PlayerController player = PlatformerModel.player;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);
            player.health.Increment();
            player.transform.position = PlatformerModel.spawnPoint.transform.position;
            player.animator.SetBool("dead", false);
            PhysicsController.SetVelocity(player, Vector2.zero);

            PlatformerModel.virtualCamera.m_Follow = player.transform;
            PlatformerModel.virtualCamera.m_LookAt = player.transform;

            Simulation.Schedule<EnablePlayerInput>(2f);
            player.simulatingPhysics = true;
        }
    }
}