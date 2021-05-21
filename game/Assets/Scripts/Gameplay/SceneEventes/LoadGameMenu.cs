using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
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

