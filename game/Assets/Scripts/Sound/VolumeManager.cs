using UnityEngine;

namespace Platformer.Sound
{
    public static class VolumeManager
    {
        private static float volume = LoadVolume();
        private const string VARIABLE_NAME = "Volume";

        public static float Volume { get => volume;}

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

