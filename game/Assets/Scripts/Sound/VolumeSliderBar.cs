using Platformer.Sound;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class VolumeSliderBar : MonoBehaviour
    {
        public AudioSource musicReproductor;
        private Slider volumeSlider;
        public Text volumeText;
        private float volume;

        private void Awake()
        {
            volume = VolumeManager.LoadVolume();
            volumeSlider = GetComponent<Slider>();
            volumeSlider.value = volume;
        }

        private void Update()
        {
            volume = volumeSlider.value;
            SetVolumeSettings();
        }

        protected virtual void SetVolumeSettings()
        {
            musicReproductor.volume = volume;
            volumeText.text = GetVolumeText();
        }

        protected string GetVolumeText()
        {
            return ((int)(volume * 100)).ToString();
        }

        private void OnDisable()
        {
            VolumeManager.SaveVolumeInFile(volume);
        }
    }
}

