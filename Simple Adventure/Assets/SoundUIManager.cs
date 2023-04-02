using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUIManager : MonoBehaviour
{
    public AudioSource buttonClick;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        buttonClick.Play();

        //Destroy(transform.gameObject, buttonClick.clip.length);
    }

    public void PlaySoundOnLoad()
    {
        buttonClick.Play();

        Destroy(gameObject, buttonClick.clip.length);
    }
}
