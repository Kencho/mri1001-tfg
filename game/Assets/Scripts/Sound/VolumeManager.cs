using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Platformer.Sound
{
    public static class VolumeManager
    {
        private static float volume;
        private const string PATH = "Files/volume.txt";

        public static float Volume { get => volume;}

        public static float LoadVolume()
        {
            string volumeFileContent = File.ReadAllText(PATH);
            volume = float.Parse(volumeFileContent);
            return volume;
        }

        public static void SaveVolumeInFile(float volume)
        {
            File.Delete(PATH);
            File.WriteAllText(PATH, volume.ToString());
        }
    }
}

