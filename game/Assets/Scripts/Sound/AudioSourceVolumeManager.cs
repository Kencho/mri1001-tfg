using UnityEngine;

namespace Platformer.Sound
{
    /// <summary>
    /// Class wrapper of AudioSources wich ensures AudioSources volume corresponds to game volume
    /// </summary>
    public class AudioSourceVolumeManager : MonoBehaviour
    {
        private float volume;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Sets AudioSource volume each Update loop
        /// </summary>
        private void Update()
        {
            UpdateVolume();
            audioSource.volume = volume;
        }

        private void UpdateVolume()
        {
            volume = VolumeManager.Volume;
        }
    }
}

