using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject []audioObjects = GameObject.FindGameObjectsWithTag("MainTheme");
        Debug.Log(audioObjects.Length);
        if (audioObjects.Length > 1)
        {
            Destroy(audioObjects[0]);
        }

        DontDestroyOnLoad(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
