using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePositionRender : MonoBehaviour
{
    private void Update()
    {
        
        if (FindObjectOfType<Board>().CheckMouseInBoard())
        {
            GetComponent<Text>().text = FindObjectOfType<Board>().GetMousePosition().ToString();
        }
        else GetComponent<Text>().text = "";
    }
}
