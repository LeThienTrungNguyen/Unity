using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerMangement : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip deadSound;

    public AudioSource source;
    // Start is called before the first frame update
    

    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
