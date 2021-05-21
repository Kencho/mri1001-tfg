using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Player;
using Platformer.Gameplay.PlayerEvents;

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

