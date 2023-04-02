using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UI_Check : MonoBehaviour
{
    [SerializeField] private int previousLevel;
    [SerializeField] int nextLevel;
    [SerializeField] public int currentLevel;
    // scriptable object
    public LevelSceneInfo lsi;
    //
    public GameObject previousLevelBtn;
    public GameObject nextLevelBtn;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = lsi.currentLevel;
        lsi.Recaculate();
        previousLevel = lsi.previousLevel;
        nextLevel = lsi.nextLevel;
        // Buttons


        // count scene in build setting
        int countScene = SceneManager.sceneCountInBuildSettings;
        // loop through each scene in build setting
        for (int i = 0; i < countScene; i++)
        {
            string formPathPrevious = "Assets/Scenes/Level/Level_" + previousLevel + ".unity";
            string formPathNext = "Assets/Scenes/Level/Level_" + nextLevel + ".unity";
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);

            Debug.Log("scene path" + scenePath);
            Debug.Log("formPathPrevious " + formPathPrevious);
            Debug.Log("formPathNext" + formPathNext);

            if (scenePath == formPathPrevious && previousLevelBtn != null)
            {
                previousLevelBtn.SetActive(true);
            }
            if (scenePath == formPathNext && previousLevelBtn != null)
            {
                nextLevelBtn.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel()
    {
        lsi.currentLevel = nextLevel;
        lsi.Recaculate();
        SceneManager.LoadScene("Assets/Scenes/Level/Level_" + nextLevel + ".unity");
    }

    public void LoadPreviousLevel()
    {
        lsi.currentLevel = previousLevel;
        lsi.Recaculate();
        SceneManager.LoadScene("Assets/Scenes/Level/Level_" + previousLevel + ".unity");
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/Level/Level_" + currentLevel + ".unity");
    }
}

