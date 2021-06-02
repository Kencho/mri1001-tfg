using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Sound.VolumeSliders
{
    /// <summary>
    /// Slider bar that modifies the volume based on the value of the slider bar
    /// </summary>
    public abstract class VolumeSliderBar : MonoBehaviour
    {
        private Slider volumeSlider;
        public Text volumeText;
        private float lastVolume;
        protected float volume;
        private AudioSource audioSource;
        public AudioClip valueChangeAudio;

        private void Awake()
        {
            LoadVolume();
            lastVolume = volume;
            volumeSlider = GetComponent<Slider>();
            volumeSlider.value = volume;
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            volume = volumeSlider.value;
            SetVolumeSettings();
            HandleAudioReproduction();
        }

        /// <summary>
        /// Changes the volume of the game accord to the variable volume
        /// </summary>
        protected virtual void SetVolumeSettings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// If volume changed reproduce valueChangeSound.
        /// </summary>
        private void HandleAudioReproduction()
        {
            if(lastVolume != volume)
            {
                audioSource.PlayOneShot(valueChangeAudio);
            }
            lastVolume = volume;
        }

        /// <summary>
        /// Gets the volume value saved in file
        /// </summary>
        protected virtual void LoadVolume()
        {
            throw new NotImplementedException();
        }

        public string GetVolumeText()
        {
            return ((int)(volume * 100)).ToString();
        }

        private void OnDisable()
        {
            SetVolumeSettings();
        }
    }
}

