﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Player;

namespace Platformer.Gameplay
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
