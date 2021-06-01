using System;
using Platformer.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    /// <summary>
    /// Slider bar that modifies the volume based on the value of the slider bar
    /// </summary>
    public class VolumeSliderBar : MonoBehaviour
    {
        private Slider volumeSlider;
        public Text volumeText;
        private float lastVolume;
        private float volume;
        private AudioSource audioSource;
        public AudioClip valueChangeAudio;

        private void Awake()
        {
            volume = VolumeManager.LoadVolume();
            lastVolume = volume;
            volumeSlider = GetComponent<Slider>();
            volumeSlider.value = volume;
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            volume = volumeSlider.value;
            VolumeManager.SetVolume(volume);
            SetVolumeSettings();
            HandleAudioReproduction();
        }

        /// <summary>
        /// Changes the volume of the game accord to the variable volume
        /// </summary>
        protected virtual void SetVolumeSettings()
        {
            VolumeManager.SetVolume(volume);
            volumeText.text = GetVolumeText();
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


        protected string GetVolumeText()
        {
            return ((int)(volume * 100)).ToString();
        }

        private void OnDisable()
        {
            VolumeManager.SetVolume(volume);
            VolumeManager.SaveVolumeInFile();
        }
    }
}

