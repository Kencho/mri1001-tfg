using System;
using Platformer.Core;
using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Platformer.UI
{
    public class OptionsCanvasManager : MonoBehaviour
    {
        private Canvas optionsPanel;
        public GameObject eventSystem;
        private bool panelActived;
        private float timeScaleBeforePanel;

        private void Awake()
        {
            InitialiceOptionsPanel();
            panelActived = false;
            ResumeGameExecution();
        }

        private void InitialiceOptionsPanel()
        {
            optionsPanel = GetComponent<Canvas>();
            optionsPanel.enabled = false;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Menu"))
            {
                panelActived = !panelActived;
                optionsPanel.enabled = panelActived;
                if (panelActived)
                {
                    PauseGameExecution();
                }
            }
            
            if(panelActived == false)
            {
                ResumeGameExecution();
            }

            eventSystem.SetActive(panelActived);
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
                optionsPanel.enabled = panelActived;
                Time.timeScale = timeScaleBeforePanel;
                timeScaleBeforePanel = 0;
                Simulation.Schedule<EnablePlayerInput>(0.2f);
            }
            
        }

        public void ActivePanel()
        {
            panelActived = true;
        }

        public void DisactivePanel()
        {
            panelActived = false;
        }

        private void BackToMainMenu()
        {
            Simulation.Schedule<LoadGameMenu>();
        }
    }
}

