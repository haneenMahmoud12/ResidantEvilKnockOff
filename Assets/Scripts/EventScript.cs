using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class EventsController : MonoBehaviour
{
    public AudioMixer effects;
    public Slider effectsSlider;
    // Start is called before the first frame update
    void Start()
    {
        effectsSlider.onValueChanged.AddListener(setMusicVolume);

    }
    public void setMusicVolume(float value)
    {
        effects.SetFloat("MyExposedParam 1", Mathf.Log10(value) * 20);
    }
}