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
        audioSource.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }

    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
    }

}
