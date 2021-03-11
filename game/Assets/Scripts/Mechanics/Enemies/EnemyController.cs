using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Player;

namespace Platformer.Enemies
{
    public class EnemyController : KinematicObject
    {
        public AudioClip ouch;
        public AudioSource _audio;

        protected override void Awake()
        {
            _audio = GetComponent<AudioSource>();
            base.Awake();
        }

        private void Update()
        {
            if(LayerContactChecker.IsInContactWithLayer(this, "Floor"))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                PlayerEnemyCollision ev = Simulation.Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }
    }
}

