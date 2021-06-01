using UnityEngine;

namespace Platformer.Sound
{
    /// <summary>
    /// Reproduces a sound when button clicked
    /// </summary>
    public class ButtonSoundReproductor : MonoBehaviour
    {
        private AudioSource audioSource;
        public AudioClip buttonPressedSound;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Method that reproduces buttonPressedSound when button clicked
        /// </summary>
        public void reproduceAudio()
        {
            audioSource.PlayOneShot(buttonPressedSound);
        }
    }
}

