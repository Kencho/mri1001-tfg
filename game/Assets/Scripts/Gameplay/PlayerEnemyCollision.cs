using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Prueba;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public Platformer.Prueba.EnemyController enemy;
        public PlayerController player;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtEnemy = player.mycollider.bounds.center.y >= enemy.mycollider.bounds.max.y;

            if (willHurtEnemy)
            {
                var enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        PhisicsControllerPrueba.ApplyImpulse(player, Vector2.up * 7);
                        Schedule<EnemyDeath>().enemy = enemy;
                    }
                    else
                    {
                        PhisicsControllerPrueba.ApplyImpulse(player, Vector2.up * 10);
                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                    PhisicsControllerPrueba.ApplyImpulse(player, Vector2.up * 7);
                }
            }
            else
            {
                Schedule<PlayerDeath>();
            }
        }
    }
}