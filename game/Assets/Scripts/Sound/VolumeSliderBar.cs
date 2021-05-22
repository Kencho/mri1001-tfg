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
            VolumeManager.SetVolume(volume);
            SetVolumeSettings();
        }

        /// <summary>
        /// Changes the volume of the game accord to the variable volume
        /// </summary>
        protected virtual void SetVolumeSettings()
        {
            VolumeManager.SetVolume(volume);
            volumeText.text = GetVolumeText();
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

