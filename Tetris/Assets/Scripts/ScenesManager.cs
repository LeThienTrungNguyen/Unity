using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class ScenesManager :MonoBehaviour
{
    public enum Scenes
    {
        MainMenu , MainGame
    }


    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
