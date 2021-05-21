using Platformer.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
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

