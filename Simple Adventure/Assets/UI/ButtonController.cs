using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelSceneInfo lsi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount==1 || Input.GetMouseButtonDown(0))
        {
            Debug.Log(1);
            SceneManager.LoadScene("Level_1");
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Level/Level_" + lsi.currentLevel + ".unity");
    }

}
