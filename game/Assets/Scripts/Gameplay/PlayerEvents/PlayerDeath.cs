﻿using Platformer.Core;
using Platformer.Gameplay.GameEvents;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.Player.PlayerStates;
using Platformer.Model;

namespace Platformer.Gameplay.PlayerEvents
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        private const float WAIT_TIME_UNTIL_PLAYER_SPAWN = 2f;

        public override void Execute()
        {
            PlayerController player = PlatformerModel.player;
            if (player.health.IsAlive)
            {
                SetDeathSettings(player);
                PlatformerModel.virtualCamera.m_Follow = null;
                PlatformerModel.virtualCamera.m_LookAt = null;
                SetDeathAnimationAndSounds(player);
                Simulation.Schedule<PlayerSpawn>(WAIT_TIME_UNTIL_PLAYER_SPAWN);
                Simulation.Schedule<SetGameInitialState>();
            }
        }

        private void SetDeathSettings(PlayerController player)
        {
            player.health.Die();
            player.simulatingPhysics = false;
            player.controlEnabled = false;
            player.ChangeState(new PlayerDeadState(player));
        }

        private void SetDeathAnimationAndSounds(PlayerController player)
        {
            if (player.audioSource && player.ouchAudio)
                player.audioSource.PlayOneShot(player.ouchAudio);
            player.animator.SetTrigger("hurt");
            player.animator.SetBool("dead", true);
        }
    }
}