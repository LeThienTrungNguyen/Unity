using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Header("Hp")]
    public int maxHp;
    [SerializeField] int hp;
    [Header("Transform ")]
    [SerializeField] Vector2 postion;
    [SerializeField] Vector2 direction;
    public Transform savePoint;
    [Header("Hurt System")]
    public bool isHurting;
    public float hurtDuration;
    public Vector2 hurtForce;
    [Header("Score")]
    public float score;
    [Header("Skin")]
    public PlayerableObject po;
    public Animator animator ;
    [Header("Sound")]
    public SoundPlayerMangement spm;
    public AudioSource audioSource;

    // Start is called before the first frame update


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        teleportToCheckPoint();
        animator.runtimeAnimatorController= po.players[po.chosenIndex].controller;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        {
            direction = getDirection();
            getPosition();
            if(hp >= maxHp)
            {
                hp = maxHp;
            }
        }

        {
            if (isHurting)
            {
                /*Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(1, 1);
                Invoke("stopHurt",hurtDuration);*/
            }

        }
    }

    public int getCurrentHP()
    {
        return hp;
    }

    void setCurrentHP(int set)
    {
        hp = set;
    }
    Vector2 getPosition()
    {
        postion = transform.position;
        return postion;
    }

    public void setPosition(Vector2 pos)
    {
        transform.position = pos;
    }

    public Vector2 getDirection()
    {
        /*Vector2 directionHorizontal;
        bool flip = transform.GetComponent<SpriteRenderer>().flipX;
        
        if (flip)
        {
            directionHorizontal = Vector2.left;
        } else
        {
            directionHorizontal = Vector2.right;
        }*/

        return direction;
    }

    public void setDirection(Vector2 directionSet)
    {
        direction = directionSet;
    }

    public void takeDamage()
    {
        // minus hp
        hp -= 1;
        // set animation hurt
        Animator anim = transform.GetComponent<Animator>();
        anim.SetTrigger("Hit");
        audioSource.clip = spm.deadSound;
        audioSource.Play();
        

        // jump up on hit
        isHurting = true;
        //check player
        check();
    }

    

    public void death()
    {
        resetStatus();
    }

    public void resetStatus()
    {
        hp = maxHp;
        teleportToCheckPoint();
    }

    public void check()
    {
        if (hp <= 0)
        {
            gameOver();
        }
    }
    public void gameOver()
    {
        SceneManager.LoadScene("FailedScence");
    }
    public void teleportToCheckPoint()
    {
        transform.position = savePoint.position;
        
    }
}
