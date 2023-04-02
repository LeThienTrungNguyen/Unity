using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagement : MonoBehaviour
{
    public static KeyCode moveLeft;
    public static KeyCode moveRight;
    public static KeyCode jump;

    // Start is called before the first frame update
    void Start()
    {
        defaultKeyboard(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Space);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public KeyCode getKeyMoveLeft()
    {
        return moveLeft;
    }

    public void setKeyMoveLeft(KeyCode set)
    {
        moveLeft = set;
    }

    public KeyCode getKeyMoveRight()
    {
        return moveRight;
    }
    
    public void setKeyMoveRight(KeyCode set)
    {
        moveRight = set;
    }

    public KeyCode getKeyJump()
    {

        return jump;
    }

    public void setKeyJump(KeyCode set)
    {
        jump = set;
    }

    public void defaultKeyboard(KeyCode moveLeft,KeyCode moveRight , KeyCode jump)
    {
        setKeyMoveLeft(moveLeft);
        setKeyMoveRight(moveRight);
        setKeyJump(jump);
    }
}
