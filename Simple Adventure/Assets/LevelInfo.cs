using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public LevelSceneInfo lsi;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        lsi.Recaculate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
