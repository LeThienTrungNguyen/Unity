using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseScene;
    public GameObject sureScene;

    private void Update()
    {
        //activePause = pauseScene.activeSelf;
    }
    public void togethePauseUIScene()
    {
        
        Debug.Log(pauseScene.activeSelf);
        if (pauseScene.activeSelf == true)
        {
            pauseScene.SetActive(false);
            setTimeScale(1);
        }
        else
        {
            pauseScene.SetActive(true);
            setTimeScale(0);
        }
    }

    public void togetheSureUIScene()
    {
        if (sureScene.activeSelf)
        {
            sureScene.SetActive(false);
            setTimeScale(1f);
        }
        else
        {
            sureScene.SetActive(true);
            setTimeScale(0f);
        }
    }

    public void setTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
