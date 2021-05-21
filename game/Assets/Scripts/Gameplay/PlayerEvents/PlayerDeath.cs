using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Gameplay.GameEvents;
using Platformer.Model;
using Platformer.Player;
using UnityEngine;

namespace Platformer.Gameplay.PlayerEvents
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        public override void Execute()
        {
            PlayerController player = PlatformerModel.player;
            if (player.health.IsAlive)
            {
                SetDeathSettings(player);
                PlatformerModel.virtualCamera.m_Follow = null;
                PlatformerModel.virtualCamera.m_LookAt = null;
                SetDeathAnimationAndSounds(player);
                Simulation.Schedule<PlayerSpawn>(2);
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