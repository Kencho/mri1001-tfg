using Platformer.Core;
using Platformer.Mechanics.Player;

namespace Platformer.Gameplay.PlayerEvents
{
    /// <summary>
    /// Event fired when PlayerCotroller collide with Obstacles
    /// </summary>
    public class PlayerObstacleCollision : Simulation.Event<PlayerObstacleCollision>
    {
        public PlayerController player;

        public override void Execute()
        {
            Simulation.Schedule<PlayerDeath>();
        }
    }
}

