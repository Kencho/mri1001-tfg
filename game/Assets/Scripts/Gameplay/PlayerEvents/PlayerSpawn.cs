using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Platformer.Physics;
using Platformer.Player;
using UnityEngine;

namespace Platformer.Gameplay
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
            PhisicsController.SetVelocity(player, Vector2.zero);

            PlatformerModel.virtualCamera.m_Follow = player.transform;
            PlatformerModel.virtualCamera.m_LookAt = player.transform;

            Simulation.Schedule<EnablePlayerInput>(2f);
            player.simulatingPhysics = true;
        }
    }
}