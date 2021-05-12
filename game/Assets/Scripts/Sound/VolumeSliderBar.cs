using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderBar : MonoBehaviour
{
    public AudioSource musicReproductor;
    private Slider volumeSlider;
    public Text volumeText;
    private float volume;
    private const string PATH = "Files/volume.txt";

    private void Awake()
    {
        volumeSlider = GetComponent<Slider>();
        LoadVolumeFromFile();
        SetVolumeSettings();
        volumeSlider.value = volume;
    }

    private void Update()
    {
        volume = volumeSlider.value;
        SetVolumeSettings();
    }

    private void OnDisable()
    {
        SaveVolumeInFile();
    }

    private void SetVolumeSettings()
    {
        musicReproductor.volume = volume;
        volumeText.text = ((int)(volume * 100)).ToString();
    }

    private void LoadVolumeFromFile()
    {
        string volumeFileContent = File.ReadAllText(PATH);
        volume = float.Parse(volumeFileContent);
    }

    private void SaveVolumeInFile()
    {
        File.Delete(PATH);
        File.WriteAllText(PATH, volume.ToString());
    }
}
