using Platformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class LoadGameMenu : Simulation.Event<PlayerDeath>
    {
        public override void Execute()
        {
            SceneManager.LoadScene("GameMenu");
        }
    }
}

