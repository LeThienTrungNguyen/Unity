using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin_Management_Player : MonoBehaviour
{
    public PlayerableObject po;
    [SerializeField] int tempIndex;
    public Image image;
    public GameObject button;

    private void Start()
    {
        tempIndex = po.chosenIndex;
        image.sprite = po.players[po.chosenIndex].avatar;
    }

    private void Update()
    {
        if (tempIndex != 0 && tempIndex < po.players.Count)
        {
            image.sprite = po.players[tempIndex].avatar;
        }

        if (tempIndex == po.chosenIndex)
        {
            hideButton();
        }
        else
        {
            showButton();
        }
    }

    public void ChangeSkin()
    {
        po.chosenIndex = tempIndex;
    }

    public void nextTempSkin()
    {
        tempIndex = (tempIndex + 1) % po.players.Count;

        if (tempIndex == 0)
        {
            tempIndex = 1;
        }
    }

    public void prevTempSkin()
    {
        tempIndex = (tempIndex - 1 + po.players.Count) % po.players.Count;
        if (tempIndex == 0)
        {
            tempIndex = po.players.Count-1;
        }
    }

    public void hideButton()
    {
        button.SetActive(false);
    }

    public void showButton()
    {
        button.SetActive(true);
    }
}
