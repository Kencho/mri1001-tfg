using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay.SceneEvents
{
    /// <summary>
    /// Event that changes the escene to GameMenu scene
    /// </summary>
    public class LoadGameMenu : Simulation.Event<PlayerDeath>
    {
        public override void Execute()
        {
            SceneManager.LoadScene("GameMenu");
        }
    }
}

