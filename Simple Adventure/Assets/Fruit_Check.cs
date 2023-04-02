using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class Fruit_Check : MonoBehaviour
{
    public AudioSource source;
    public Transform fruits;
    [SerializeField] int fruitRoom;
    [SerializeField] int fruitLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fruitRoom = countFruitInRoom();
        fruitLevel = countFruitInLevel();
        if (transform.gameObject.tag == "Door_Final")
        {
            if(countFruitInLevel() == 0)
            {
                destroyMe();
            }
        }else
        if (countFruitInRoom() == 0)
        {
            destroyMe();
        }
    }

    public int countFruitInRoom()
    {
        int count = fruits.childCount;

        return count;
    }

    public int countFruitInLevel()
    {
        int count = GameObject.FindGameObjectsWithTag("Fruits").Length;
        return count;
    }


    void destroyMe()
    {
        Destroy(transform.gameObject, source.clip.length);
    }

    public void OnDestroy()
    {
        // play sound detect all of fruit in room were collect
        source.Play();
    }
}

public class ReadOnlyAttribute : PropertyAttribute { }
