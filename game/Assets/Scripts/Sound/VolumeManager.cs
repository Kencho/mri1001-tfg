using System;
using UnityEngine;

namespace Platformer.Sound
{
    /// <summary>
    /// Class that manages the volume of the game.
    /// This class can manages two volume types:
    ///     The volume applied over all AudioSources
    ///     The volume applied just to music AudioSources
    /// </summary>
    public static class VolumeManager
    {
        private static float generalVolume = LoadGeneralVolume();
        private static float musicVolume = LoadMusicVolume();

        private const string GENERAL_VOLUME_VARIABLE_NAME = "Volume";
        private const string MUSIC_VOLUME_VARIABLE_NAME = "MusicVolume";

        public static float GeneralVolume { get => generalVolume;}
        public static float MusicVolume { get => musicVolume;}

        /// <summary>
        /// Set volume based in the value stored in a file 
        /// </summary>
        /// <returns>volume stored</returns>
        public static float LoadGeneralVolume()
        {
            generalVolume = PlayerPrefs.GetFloat(GENERAL_VOLUME_VARIABLE_NAME, 100);
            return generalVolume;
        }

        public static void SetGeneralVolume(float volume)
        {
            VolumeManager.generalVolume = volume;
            SaveVolumeInFile(GENERAL_VOLUME_VARIABLE_NAME, generalVolume);
        }

        /// <summary>
        /// Set music volume based in the value stored in a file 
        /// </summary>
        /// <returns>music volume stored</returns>
        public static float LoadMusicVolume()
        {
            musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_VARIABLE_NAME, 100);
            return musicVolume;
        }

        public static void SetMusicVolume(float volume)
        {
            VolumeManager.musicVolume = volume;
            SaveVolumeInFile(MUSIC_VOLUME_VARIABLE_NAME, musicVolume);
        }

        /// <summary>
        /// This methods makes persistent the volume value of the type of volume passed througth parameters
        /// </summary>
        /// <param name="volumeType">string associated with the volume type</param>
        /// <param name="volume">volume value saved</param>
        private static void SaveVolumeInFile(string volumeType, float volume)
        {
            PlayerPrefs.SetFloat(volumeType, volume);
        }
    }
}

