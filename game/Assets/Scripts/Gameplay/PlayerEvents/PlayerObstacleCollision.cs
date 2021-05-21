using Platformer.Core;
using Platformer.Mechanics.Player;

namespace Platformer.Gameplay.PlayerEvents
{
    public class PlayerObstacleCollision : Simulation.Event<PlayerObstacleCollision>
    {
        public PlayerController player;

        public override void Execute()
        {
            Simulation.Schedule<PlayerDeath>();
        }
    }
}

