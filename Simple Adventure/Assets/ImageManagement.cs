using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageManagement : MonoBehaviour
{
    public Sprite imageLock;
    public Sprite imageUnlock;
    public bool isLock;
    public string levelName;
    public LevelSceneInfo levelSceneInfo;

    private void Update()
    {
        unlockFinalLevel();
        bool canConvert = int.TryParse(levelName, out _);
        int index = -1;
        if (canConvert)
        {
            index = int.Parse(levelName);
        }
        else if (levelName == "Special")
        {
            index = levelSceneInfo.levels.Count - 1;
        }

        if (index > 1 && index != levelSceneInfo.levels.Count - 1)
        {
            isLock = !levelSceneInfo.levels[index - 1].isCompleted;
        }

        Image image = GetComponent<Image>();
        image.sprite = GetImageSprite();
        image.color = GetImageColor();
    }

    private Sprite GetImageSprite()
    {
        Image image = GetComponent<Image>();
        if (levelName == "Special")
        {
            return isLock ? null : imageUnlock;
        }
        else
        {
            return isLock ? imageLock : imageUnlock;
        }
    }

    private Color GetImageColor()
    {
        if (levelName == "Special")
        {
            return isLock ? new Color(1f, 1f, 1f, 0f) : Color.white;
        }
        else
        {
            return Color.white;
        }
    }

    public void CheckClick(string levelName)
    {
        if (!isLock)
        {
            SceneManager.LoadScene("Level_" + levelName);
            if(int.TryParse(levelName,out _))
            {
                levelSceneInfo.currentLevel = int.Parse(levelName);
                
            }else
            {
                Debug.Log("Cant Parse");
            }
        }
    }

    public void unlockFinalLevel()
    {
        if(levelName == "Special")
        {
            bool isLockFinalLevel = false;
            for (int i = 1; i < levelSceneInfo.levels.Count-1; i++)
            {
                if (levelSceneInfo.levels[i].rank != Level_OOP.Ranks.S)
                {
                    isLockFinalLevel = true;
                }
            }

            isLock = isLockFinalLevel ? true : false;
        }
        
    }
}
