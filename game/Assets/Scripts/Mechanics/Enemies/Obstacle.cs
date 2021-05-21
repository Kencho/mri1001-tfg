using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Gameplay.PlayerEvents;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.TimeModifiers;

namespace Platformer.Mechanics.Enemies
{
    public class Obstacle : TimeAffectedObject
    {
        private Collider2D obstacleCollider;

        private void Awake()
        {
            obstacleCollider = GetComponent<Collider2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                PlayerObstacleCollision ev = Simulation.Schedule<PlayerObstacleCollision>();
                ev.player = player;
            }
        }

        protected override void Move()
        {

        }
    }
}

