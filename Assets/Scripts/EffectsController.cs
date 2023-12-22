using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class EffectsController : MonoBehaviour
{
    public AudioMixer effect;
    public Slider effectsSlider;
    // Start is called before the first frame update
    void Start()
    {
        effectsSlider.onValueChanged.AddListener(setMusicVolume);

    }
    public void setMusicVolume(float value)
    {
        effect.SetFloat("Effects", Mathf.Log10(value) * 20);
    }
    // Update is called once per frame
    void Update()
    {

    }
}