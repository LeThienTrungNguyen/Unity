using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Movement : MonoBehaviour
{
    //Sound
    public List<AudioClip> listAudio = new List<AudioClip>();


    //
    public float scale;
    public float stepTime;

    public float stepTimeDefault;
    public float fastStep;
    public float fallTime;
    // valid position
    public float bottomPos;
    public float leftPos;
    public float rightPos;
    // my position
    public Vector2 myPosition;
    //
    public Transform rotatePoint;

    //
    public static Transform[,] grid = new Transform[10, 20];
    private void Awake()
    {
        stepTimeDefault = stepTime;
    }

    private void Start()
    {
        stepTime = stepTimeDefault;
        Time.timeScale = 1;
    }

    private void Update()
    {
        CheckLine();
        // check empty direction on touching
        GameObject empty = GameObject.Find("Empty");
        if(empty != null)
        {
            
            if(empty.transform.position.y > transform.position.y)
            {
                RotationRight();
            } else
            if(empty.transform.position.y < transform.position.y && empty.transform.position.x >= minXPosition() && empty.transform.position.x <= maxXPosition())
            {
                stepTime = fastStep;

            }else
            if (empty.transform.position.x > maxXPosition())
            {
                MoveRight();
            }
            else if(empty.transform.position.x < minXPosition())
            {
                MoveLeft();
            }

            Destroy(empty);
        }
        //


        //test button , will remove this code after
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }
        myPosition = transform.position;
        // move horizonal by keyboard
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1 * scale, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(-1 * scale, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1 * scale, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1 * scale, 0, 0);
        }
        // key rotate
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotationLeft();
            if (!ValidMove())
            {
                RotationRight();
            }
        }

        // move down auto
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stepTime = fastStep;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            stepTime = stepTimeDefault;
        }
        if (Time.time - stepTime > fallTime)
        {
            transform.position += new Vector3(0, -1 * scale, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1 * scale, 0);
                
                this.enabled = false;

                
                addGrid();

                StartCoroutine(Delay(1));
            }
            fallTime = Time.time;
        }

    }

    IEnumerator Delay(float time)
    {
        CheckLine();
        yield return new WaitForSeconds(time);
        Debug.Log(1); //
                      FindObjectOfType<SpawnTetromino>().IntiniateTetromino();
    }

    bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            if (child.position.x <= leftPos || child.position.x >= rightPos || child.position.y <= bottomPos)
            {
                return false;
            }

            if (isObjectBottom())
            {
                return false;
            }

        }

        return true;
    }

    void RotationLeft()
    {
        transform.RotateAround(rotatePoint.position, new Vector3(0, 0, 1), 90);
        if (!ValidMove())
        {
            RotationRight();
        }
    }

    void RotationRight()
    {
        transform.RotateAround(rotatePoint.position, new Vector3(0, 0, 1), -90);
        if (!ValidMove())
        {
            RotationLeft();
        }
    }
    LayerMask layer;
    bool isObjectBottom()
    {
        foreach (Transform child in transform)
        {
            RaycastHit2D rayhit = Physics2D.Raycast(child.position, Vector2.down,0.1f);
            if (rayhit)
            {
                if (rayhit.transform.tag == "Tetromino" && rayhit.transform.parent != child.parent)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void addGrid()
    {
        foreach(Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.position.x);
            int y = 0 ;

            y = Mathf.RoundToInt(child.position.y);
            Debug.Log(y);
            if (y >= 19)
            {
                GameOver();
            } else
            {
                grid[x, y] = child;
            }
            
            
            

        }
    }
    
    public void CheckLine()
    {
        for (int row=0; row < grid.GetLength(1);row++)
        {
            if (HasLine(row))
            {
                RemoveLine(row);
                RowDown(row);
            }
        }
    }

    bool HasLine(int row)
    {
        for (int cell = 0;cell < grid.GetLength(0);cell++)
        {
            if (grid[cell, row] == null)
            {
                return false;
            }
        }
        return true;
    }

    void RemoveLine(int row)
    {
        for(int cell =0;cell< grid.GetLength(0); cell++)
        {
            
            Destroy(grid[cell, row].gameObject);
            grid[cell, row] = null;
        }
    }
    void RowDown(int rowIndexFromHeight)
    {
        Score.score += 10;
        // play sound
        AudioSource source = GetComponent<AudioSource>();
        source.clip = listAudio[0];
        source.Play();
        //
        for (int row = rowIndexFromHeight; row < grid.GetLength(1); row++)
        {
            for(int cell = 0;cell < grid.GetLength(0); cell++)
            {
                if(grid[cell,row] != null)
                {
                    grid[cell, row - 1] = grid[cell, row];
                    grid[cell, row] = null;
                    grid[cell, row - 1].transform.position += Vector3.down;
                }
            }
        }
    }

    void MoveLeft()
    {
        transform.position += new Vector3(-1 * scale, 0, 0);
        if (!ValidMove())
            transform.position -= new Vector3(-1 * scale, 0, 0);
    }
    void MoveRight()
    {
        transform.position += new Vector3(1 * scale, 0, 0);
        if (!ValidMove())
            transform.position -= new Vector3(1 * scale, 0, 0);
    }

    int maxXPosition()
    {
        int maxValue = 0;
        foreach(Transform child in transform)
        {
            if (maxValue < child.GetComponent<BoxCollider2D>().bounds.max.x) 
            {
                maxValue = Mathf.RoundToInt(child.GetComponent<BoxCollider2D>().bounds.max.x);
            }
        }

        return maxValue;
    }

    int minXPosition()
    {
        int minValue = grid.GetLength(1);
        foreach (Transform child in transform)
        {
            if (minValue > child.GetComponent<BoxCollider2D>().bounds.min.x)
            {
                minValue = Mathf.RoundToInt(child.GetComponent<BoxCollider2D>().bounds.min.x);
            }
        }

        return minValue;
    }


    public Transform GameOverScene;
    void GameOver()
    {
        GameObject canvas = GameObject.Find("Canvas");
        Time.timeScale = 0;
        if (canvas != null)
        {
            canvas.transform.GetChild(1).gameObject.SetActive(true);
        }
    }


}
