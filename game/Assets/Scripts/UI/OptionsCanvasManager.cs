using Platformer.Core;
using Platformer.Gameplay.PlayerEvents;
using Platformer.Gameplay.SceneEvents;
using UnityEngine;

namespace Platformer.UI
{
    /// <summary>
    /// Class used to build pause menu
    /// </summary>
    public class OptionsCanvasManager : MonoBehaviour
    {
        /// <summary>
        /// Panel that shows options menu
        /// </summary>
        private Canvas optionsPanel;
        /// <summary>
        /// EventSystem that manages menu inputs
        /// </summary>
        public GameObject eventSystem;
        /// <summary>
        /// ¿Is the pause menu shown?
        /// </summary>
        private bool panelActivated;
        /// <summary>
        /// Variable used to restore the correct state of the game when pause menu is switch off
        /// </summary>
        private float timeScaleBeforePanel;

        private void Awake()
        {
            InitializeOptionsPanel();
            panelActivated = false;
            ResumeGameExecution();
        }

        private void InitializeOptionsPanel()
        {
            optionsPanel = GetComponent<Canvas>();
            optionsPanel.enabled = false;
        }

        /// <summary>
        /// Checks if pause menu is actived every Update loop
        /// </summary>
        private void Update()
        {
            if (Input.GetButtonDown("Menu"))
            {
                panelActivated = !panelActivated;
                optionsPanel.enabled = panelActivated;
                if (panelActivated)
                {
                    PauseGameExecution();
                }
            }
            
            if(panelActivated == false)
            {
                ResumeGameExecution();
            }

            eventSystem.SetActive(panelActivated);
        }

        private void PauseGameExecution()
        {
            Simulation.Schedule<DisablePlayerInput>();
            timeScaleBeforePanel = Time.timeScale;
            Time.timeScale = 0;
        }

        private void ResumeGameExecution()
        {
            if(timeScaleBeforePanel != 0)
            {
                optionsPanel.enabled = panelActivated;
                Time.timeScale = timeScaleBeforePanel;
                timeScaleBeforePanel = 0;
                Simulation.Schedule<EnablePlayerInput>(0.2f);
            }
            
        }

        public void ActivatePanel()
        {
            panelActivated = true;
        }

        public void DeactivatePanel()
        {
            panelActivated = false;
        }

        private void BackToMainMenu()
        {
            Simulation.Schedule<LoadGameMenu>();
        }
    }
}

