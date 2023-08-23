using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Find the PersistentAudio GameObject and get its AudioSource component
        audioSource = FindObjectOfType<PersistentAudio>().GetComponent<AudioSource>();

        // Initialize volume and slider position
        audioSource.volume = VolumeManager.masterVolume;
        volumeSlider.value = VolumeManager.masterVolume;
    }

    void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(volumeSlider.value); });
    }

    void ChangeVolume(float sliderValue)
    {
        // Update the master volume value
        VolumeManager.masterVolume = volumeSlider.value;

        // Set the volume of the audio source
        audioSource.volume = VolumeManager.masterVolume;
    }

    void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }
}
