using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Sound.AudioSources
{
    public class AudioSourceMusicVolumeManager : AudioSourceVolumeManager
    {
        protected override void UpdateVolume()
        {
            base.UpdateVolume();
            volume *= VolumeManager.MusicVolume;
        }
    }

}
