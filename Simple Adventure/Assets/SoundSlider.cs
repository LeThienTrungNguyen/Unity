using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] public Slider sliderSound;
    [SerializeField] public  Text sliderText;
    public AudioSource source;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSoundValue()
    {
        sliderText.text = sliderSound.value.ToString();
        audioMixer.SetFloat("volumn", sliderSound.value);
        source.Play();
    }
}
