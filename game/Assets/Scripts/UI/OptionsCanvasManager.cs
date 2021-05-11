using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    public class OptionsCanvasManager : MonoBehaviour
    {
        public Canvas optionsPanel;
        private bool panelActived;
        private float timeScaleBeforePanel;

        private void Awake()
        {
            InitialiceOptionsPanel();
            timeScaleBeforePanel = 0;
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

            
        }

        private void PauseGameExecution()
        {
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

        public void BackToMainMenu()
        {
            Simulation.Schedule<LoadGameMenu>();
        }
    }
}

