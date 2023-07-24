using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
        audioSource.volume = VolumeManager.masterVolume;
        // Set the initial position of the slider to match the masterVolume value
        volumeSlider.value = VolumeManager.masterVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(volumeSlider.value); });
        
    }

    // Called when Slider is moved
    void ChangeVolume(float sliderValue)
    {
        VolumeManager.masterVolume = volumeSlider.value;
        audioSource.volume = VolumeManager.masterVolume;
    }
    
}
