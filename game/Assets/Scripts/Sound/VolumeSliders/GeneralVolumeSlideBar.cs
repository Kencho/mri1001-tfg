using UnityEngine;

namespace Platformer.Sound.VolumeSliders
{
    public class GeneralVolumeSlideBar : VolumeSliderBar
    {
        protected override void SetVolumeSettings()
        {
            VolumeManager.SetGeneralVolume(volume);
            volumeText.text = GetVolumeText();
        }

        protected override void LoadVolume()
        {
            volume = VolumeManager.LoadGeneralVolume();
        }
    }
}

