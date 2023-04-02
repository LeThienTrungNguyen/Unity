using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin_Management_Fruit : MonoBehaviour
{
    public FruitableObject fo;
    [SerializeField] int tempIndex;
    public Image image;
    public GameObject button;

    private void Start()
    {
        tempIndex = fo.chosenIndex;
        image.sprite = fo.fruits[fo.chosenIndex].avatar;
    }

    private void Update()
    {
        if (tempIndex != 0 && tempIndex < fo.fruits.Count)
        {
            image.sprite = fo.fruits[tempIndex].avatar;
        }

        if (tempIndex == fo.chosenIndex)
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
        fo.chosenIndex = tempIndex;

        
    }

    public void nextTempSkin()
    {
        tempIndex = (tempIndex + 1) % fo.fruits.Count;
        if (tempIndex == 0)
        {
            tempIndex = 1;
        }
    }

    public void prevTempSkin()
    {
        tempIndex = (tempIndex - 1 + fo.fruits.Count) % fo.fruits.Count;

        if (tempIndex == 0)
        {
            tempIndex = fo.fruits.Count - 1;
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
