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
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            PlayerController player = model.player;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);
            player.health.Increment();
            player.transform.position = model.spawnPoint.transform.position;
            player.animator.SetBool("dead", false);
            PhisicsController.SetVelocity(player, Vector2.zero);

            model.virtualCamera.m_Follow = player.transform;
            model.virtualCamera.m_LookAt = player.transform;

            Simulation.Schedule<EnablePlayerInput>(2f);
            player.simulatingPhysics = true;
        }
    }
}