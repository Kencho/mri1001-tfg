using UnityEngine;

namespace Platformer.Sound.MusicReproductor
{
    /// <summary>
    /// MusicReproductor that reproduces the same song between scenes
    /// </summary>
    public class MusicReproductorInterScenes : MusicReproductor
    {
        private const string SONG_TIME_VARIABLE_NAME = "SongTime";

        protected override void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            LoadSongTime();
            audioSource.Play();
        }

        public void SaveSongTime()
        {
            PlayerPrefs.SetFloat(SONG_TIME_VARIABLE_NAME, audioSource.time);
        }

        private void LoadSongTime()
        {
            audioSource.time = PlayerPrefs.GetFloat(SONG_TIME_VARIABLE_NAME, 0);
        }

        /// <summary>
        /// Makes sure the next time the song will reproduce it will start reproducing at the begining
        /// </summary>
        public void ResetSongTime()
        {
            PlayerPrefs.DeleteKey(SONG_TIME_VARIABLE_NAME);
        }
    }
}

