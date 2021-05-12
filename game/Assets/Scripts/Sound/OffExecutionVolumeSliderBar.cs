using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    public class OffExecutionVolumeSliderBar : VolumeSliderBar
    {
        protected override void SetVolumeSettings()
        {
            volumeText.text = GetVolumeText();
        }
    }
}

