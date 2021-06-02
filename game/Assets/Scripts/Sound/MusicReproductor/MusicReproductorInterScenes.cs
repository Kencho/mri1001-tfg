using UnityEngine;

namespace Platformer.Sound.MusicReproductor
{
    /// <summary>
    /// MusicReproductor that reproduces the same song between scenes
    /// </summary>
    public class MusicReproductorInterScenes : MusicReproductor
    {
        private static float songTime = 0;

        protected override void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            LoadSongTime();
            audioSource.Play();
        }

        public void SaveSongTime()
        {
            songTime = audioSource.time;
        }

        private void LoadSongTime()
        {
            audioSource.time = songTime;
        }

        /// <summary>
        /// Makes sure the next time the song will reproduce it will start reproducing at the begining
        /// </summary>
        public void ResetSongTime()
        {
            songTime = 0;
        }
    }
}

