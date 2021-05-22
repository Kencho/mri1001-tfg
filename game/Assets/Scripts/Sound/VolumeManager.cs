using UnityEngine;

namespace Platformer.Sound
{
    /// <summary>
    /// Class that manages the volume of the game
    /// </summary>
    public static class VolumeManager
    {
        private static float volume = LoadVolume();
        private const string VARIABLE_NAME = "Volume";

        public static float Volume { get => volume;}

        /// <summary>
        /// Set volume based in the value stored in a file 
        /// </summary>
        /// <returns>volume stored</returns>
        public static float LoadVolume()
        {
            volume = PlayerPrefs.GetFloat(VARIABLE_NAME, 100);
            return volume;
        }

        public static void SetVolume(float volume)
        {
            VolumeManager.volume = volume;
            SaveVolumeInFile();
        }

        public static void SaveVolumeInFile()
        {
            PlayerPrefs.SetFloat(VARIABLE_NAME, volume);
        }
    }
}

