using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits_Scr : MonoBehaviour
{
    public FruitableObject fo;
    public Animator animator;

    [SerializeField] private int index;

    [SerializeField] AudioSource collectedSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        index = fo.chosenIndex;
        animator.runtimeAnimatorController = fo.fruits[index].controller;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Animator a = GetComponent<Animator>();
            a.SetTrigger("Collect");
            collectedSound.Play();
        }
    }
}
