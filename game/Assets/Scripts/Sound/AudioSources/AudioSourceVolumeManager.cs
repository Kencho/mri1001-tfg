using UnityEngine;

namespace Platformer.Sound.AudioSources
{
    /// <summary>
    /// Class wrapper of AudioSources wich ensures AudioSources volume corresponds to game volume
    /// </summary>
    public class AudioSourceVolumeManager : MonoBehaviour
    {
        protected float volume;
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

        protected virtual void UpdateVolume()
        {
            volume = VolumeManager.GeneralVolume;
        }
    }
}

