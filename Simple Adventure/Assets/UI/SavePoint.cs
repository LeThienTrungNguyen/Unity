using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public Transform savePoint;
    public AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playAnimCounter = 1;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int playAnimCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setSavePoint();
        if (collision.gameObject.tag == "Player" && playAnimCounter >0)
        {
            if(transform.tag == "CheckPoint")
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("Flag_Out");
                playAnimCounter--;
                // play source audio
                audioSource.clip = audioClip;
                audioSource.Play();
            } else if (transform.tag == "StartPoint")
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("Moving");
                playAnimCounter--;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        playAnimCounter++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        setSavePoint();
        
    }
    void setSavePoint()
    {
        GameObject finder = GameObject.Find("SavePoint");
        if (finder != null)
        {
            savePoint.position = transform.position;
        }
        else
        {
            Transform newSavePoint = Instantiate(savePoint, transform.position, transform.rotation);
        }
    }
}
