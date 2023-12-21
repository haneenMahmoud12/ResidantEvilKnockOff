using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundsController : MonoBehaviour
{
    public AudioMixer music;
    public Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.onValueChanged.AddListener(setMusicVolume);

    }
   public void setMusicVolume(float value)
    {
        music.SetFloat("MyExposedParam", Mathf.Log10(value)*20);
    }
    // Update is called once per frame
    void Update()
    {

    }
}