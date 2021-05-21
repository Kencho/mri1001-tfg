using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay.SceneEvents
{
    public class LoadGameMenu : Simulation.Event<PlayerDeath>
    {
        public override void Execute()
        {
            SceneManager.LoadScene("GameMenu");
        }
    }
}

