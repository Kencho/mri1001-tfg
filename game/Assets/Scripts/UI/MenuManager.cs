using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
    /// <summary>
    /// Class that contains the methods called by buttons of the main menu
    /// </summary>
    public class MenuManager : MonoBehaviour
    {
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void QuitAplication()
        {
            Application.Quit();
        }
    }
}

