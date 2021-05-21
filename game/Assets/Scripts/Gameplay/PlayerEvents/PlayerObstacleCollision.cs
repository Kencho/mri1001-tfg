﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
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

