using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchController : MonoBehaviour
{

    [SerializeField]Player player;
    // Start is called before the first frame update
    void Start()
    {
        buttonMove = transform.GetComponent<Button>();
        //player = transformTarget.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Transform transformTarget;

    public Button buttonMove;
    public Button buttonJump;
    public void clickDown()
    {
        Debug.Log("Clicked Down");
        if(transform.gameObject.name == "ButtonTouchLeft")
        {
            player.setDirection(Vector2.left);
        }
        if (transform.gameObject.name == "ButtonTouchRight")
        {
            player.setDirection(Vector2.right);
        }
        if(transform.gameObject.name == "ButtonTouchJump")
        {
            Movement movement = player.GetComponent<Movement>();
            if (movement.isGrounded())
            {
                movement.doJump();
            }
        }
    }

    public void clickUp()
    {
        player.setDirection(Vector2.zero);
        Debug.Log("Clicked Up");
    }
    
}
