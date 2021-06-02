namespace Platformer.Sound.VolumeSliders
{
    /// <summary>
    /// VolumeSliderBar specific to change music volume
    /// </summary>
    public class MusicVolumeSliderBar : VolumeSliderBar
    {
        protected override void SetVolumeSettings()
        {
            VolumeManager.SetMusicVolume(volume);
            volumeText.text = GetVolumeText();
        }

        protected override void LoadVolume()
        {
            volume = VolumeManager.LoadMusicVolume();
        }
    }
}

