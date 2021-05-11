using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
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

