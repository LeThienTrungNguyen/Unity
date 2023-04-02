using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpawnTetromino : MonoBehaviour
{
    public  List<Transform> tetrominos = new List<Transform>();
    public  Transform nextTetromino;

    // Start is called before the first frame update
    

    void Start()
    {
        IntiniateTetromino();
    }

    private void Update()
    {

    }

    // Update is called once per frame
    public void IntiniateTetromino()
    {
        
            Vector3 spawnPosition;
            int index = Random.Range(0, tetrominos.Count);
            if (tetrominos[index].name.Contains("O Tetromino"))
            {
                spawnPosition = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, transform.position.z);
            }
            else
            {
                spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            Instantiate(tetrominos[index], spawnPosition, Quaternion.identity, transform);
        
    }
}
