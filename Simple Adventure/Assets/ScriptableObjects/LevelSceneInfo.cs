using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="LevelSceneInfo",menuName = "ScriptableObjects")]
public class LevelSceneInfo : ScriptableObject
{
    public int previousLevel;
    public int currentLevel;
    public int nextLevel;
    //[SerializeField] int setCount = 1;

    public List<Level_OOP> levels = new List<Level_OOP>();
    

    public void Recaculate()
    {
        previousLevel = currentLevel - 1;
        nextLevel = currentLevel + 1;
    }

    public void setLevel(string name , bool isLock)
    {
        
    }


}


