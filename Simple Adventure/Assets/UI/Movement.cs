using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    InputManagement input;
    public float movespeed;
    Rigidbody2D rb2D;
    Animator animator;
    [SerializeField] Vector2 _direction;

    [SerializeField] bool checkGrounded;

    [Header("Jump System")]
    public float jumphight;
    [SerializeField] bool canJumpInAir;
    public int jumpCounter;
    public Vector2 wallJumpForce;
    public float wallJumpDuration;
    public bool canWallJump;

    [Header("Slide System")]
    [SerializeField] bool isSliding;
    public float slideSpeed;
    //condition that when player slide , cant not wall jump , and reverse
    public float condition1;

    [Header("Layer")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform wallCheck;
    public Transform wallCheck1;
    public LayerMask wallLayer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    [SerializeField] float mySpeed;
    void movement()
    {
        Player player = GetComponent<Player>();
        //started
        {
            if (isGrounded()) jumpCounter = 1;
            isSliding = (onWall() && !isGrounded());
            flipImage();
            animatorController();
            
        }
        // set speed for velocity
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.setDirection(Vector2.left);

            //myDirectionHorizontal(Vector2.left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.setDirection(Vector2.right);
            //myDirectionHorizontal(Vector2.right);
        }
        mySpeed = player.getDirection().x * movespeed;
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            player.setDirection(Vector2.zero);
            //mySpeed = 0;
        }
        // set velocity
        rb2D.velocity = new Vector2(mySpeed, rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isGrounded())
            {
                doJump();
            }
            else
            {
                if (canJumpInAir && jumpCounter > 0)
                {

                    doJump();
                    jumpCounter = 0;
                }
            }


        }

        /*if (isSliding && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && rb2D.velocity.y<0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -slideSpeed*//*Mathf.Clamp(rb2D.velocity.y , -slideSpeed,float.MaxValue)*//*);
            jumpCounter = 0;
            if (Input.GetKeyDown(KeyCode.X))
            {
                canWallJump = true;
            }
        }
        // wall jump
        if(canWallJump)
        {
            doWallJump();
        }*/

    }

    // do wall jump
    void doWallJump()
    {
        Player p = transform.GetComponent<Player>();
        float direction = p.getDirection().x/Mathf.Abs(p.getDirection().x);
        rb2D.velocity = new Vector2(-direction * wallJumpForce.x, Mathf.Abs(direction) * wallJumpForce.y);
        //rb2D.AddForce(new Vector2(direction * wallJumpForce.x, Mathf.Abs(direction) * wallJumpForce.y),ForceMode2D.Force);
        Invoke("stopWallJump", wallJumpDuration);
    }

    void stopWallJump()
    {
        canWallJump = false;
    }

    //check player on ground
    public bool isGrounded()
    {
        return Physics2D.CapsuleCast(transform.position, transform.GetComponent<CapsuleCollider2D>().bounds.size, CapsuleDirection2D.Horizontal, 0f, Vector2.down, 0.1f, groundLayer);
    }
    // check player on wall
    bool onWall()
    {
        return Physics2D.OverlapBox(wallCheck1.position, new Vector2(0.04f, 0.25f), 0, wallLayer)
            || Physics2D.OverlapBox(wallCheck.position, new Vector2(0.04f, 0.25f), 0, wallLayer)
            ;
    }
    Vector2 myDirectionHorizontal(Vector2 set)
    {
        return set;
    }
    void animatorController()
    {
        if (animator!=null)
        {
            animator.SetBool("IsGrounded", isGrounded());
            if (isGrounded())
            {
                if (mySpeed != 0)
                {
                    animator.SetBool("IsWalking", true);
                }
                else
                {
                    animator.SetBool("IsWalking", false);
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    animator.SetTrigger("Jump");
                }
            }
            else
            {
                animator.SetBool("IsWalking", false);
                if (Input.GetKeyDown(KeyCode.X) && canJumpInAir)
                {
                    animator.SetTrigger("DoubleJump");
                }
            }

            animator.SetFloat("VelocityV", rb2D.velocity.y);
            if (isSliding && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && rb2D.velocity.y < 0)
            {
                animator.SetBool("IsSliding", isSliding);
            }
            else if (!isSliding)
            {
                animator.SetBool("IsSliding", isSliding);
            }
            // color 80006D
        }
    }

    void flipImage()
    {
        SpriteRenderer sp = transform.GetComponent<SpriteRenderer>();
        if (mySpeed > 0)
        {
            sp.flipX = false;
        }
        if (mySpeed < 0)
        {
            sp.flipX = true;
        }
    }

    public void doJump()
    {
        rb2D.velocity = Vector2.up * jumphight;
        SoundPlayerMangement spm = GetComponent<SoundPlayerMangement>();
        spm.PlaySound(spm.jumpSound);
    }

    
}
