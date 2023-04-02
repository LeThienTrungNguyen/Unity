using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Levels : MonoBehaviour
{
    public LevelSceneInfo lsi;
    public Transform scene;
    // Start is called before the first frame update
    
    public void resetAllLevel()
    {
        for(int i = 1;i< lsi.levels.Count; i++)
        {
            lsi.levels[i].isCompleted = false;
            lsi.levels[i].rank = Level_OOP.Ranks.Zero;
            lsi.levels[i].score = -1;
        }
        lsi.currentLevel = 1;
        scene.gameObject.SetActive(false);
    }
}
