using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public List<string> sceneNames = new List<string>();
    public AudioSource source;
    public int counterPlay;
    // Start is called before the first frame update
    void Start()
    {
        GameObject [] objectAudio = GameObject.FindGameObjectsWithTag("Audio");
        if (objectAudio.Length > 1)
        {
            Destroy(objectAudio[objectAudio.Length-1]);
        }
        counterPlay = 1;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // mute when current scene with name
        foreach(string name in sceneNames)
        {
            if (checkSceneName(name))
            {
                source.mute = true;
                counterPlay = 1;
            }
            else
            {
                if (counterPlay > 0)
                {
                    counterPlay = 0;
                    source.Play();
                    source.mute = false;
                }
            };
        }
    }
    bool checkSceneName(string name)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == name)
        {
            return true;
        }
        else return false;
    }
}
