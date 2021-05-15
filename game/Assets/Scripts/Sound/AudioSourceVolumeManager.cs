using UnityEngine;

namespace Platformer.Sound
{
    public class AudioSourceVolumeManager : MonoBehaviour
    {
        private float volume;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

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

