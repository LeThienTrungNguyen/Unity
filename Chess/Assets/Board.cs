using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int boardWidth = 8;
    public static int boardHeight = 8;
    public Color BoardColor1;
    public Color BoardColor2;

    public Transform boardIndex;

    public static Transform[,] board;
    public static Transform[,] chessPosition;
    public static Color[,] colorIndex;

    public static Transform chosenChess;

    public static bool[,] validMoves = new bool[8, 8];
    // Start is called before the first frame update
    void Start()
    {
        ClearValidMoves();
        BoardInit();
    }

    public Vector3Int worldMousePos;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldMousePos.x = Mathf.RoundToInt(mousePos.x);
            worldMousePos.y = Mathf.RoundToInt(mousePos.y);
            worldMousePos.z = Mathf.RoundToInt(mousePos.z);

            if (chosenChess != null)
            {
                Debug.Log(chosenChess);
                for(int x = 0;x< validMoves.GetLength(0); x++)
                {
                    for (int y = 0; y < validMoves.GetLength(1); y++)
                    {
                        Debug.Log("board "+board[x, y].position);
                        Debug.Log("mouse " + worldMousePos);
                        if (worldMousePos.x == Mathf.RoundToInt(board[x, y].position.x)
                            && worldMousePos.y == Mathf.RoundToInt(board[x, y].position.y
                            ) && validMoves[x,y])
                        {
                            Debug.Log(1);
                            chosenChess.position = new Vector3Int(worldMousePos.x, worldMousePos.y, Mathf.RoundToInt(chosenChess.position.z));

                            if (chosenChess.GetComponent<Chess>().chessType == Chess.ChessType.Pawn)
                            {
                                chosenChess.GetComponent<Chess>().isFirstMove = false;
                            }
                            chosenChess = null;
                            ClearValidMoves();

                            toggleRender = !toggleRender;
                            RenderValidMoves();
                            toggleRender = !toggleRender;

                        }
                    }
                }
            }
        }
    }



    void BoardInit()
    {
        chessPosition = new Transform[boardWidth, boardHeight];
        board = new Transform[boardWidth, boardHeight];
        colorIndex = new Color[boardWidth, boardHeight];
        // create transform and change color
        for (int cell = 0; cell < boardWidth; cell++)
        {
            for(int row = 0;row < boardHeight; row++)
            {
                board[cell, row] = Instantiate(boardIndex, new Vector2(cell, row),transform.rotation,transform);
                
                if( (cell % 2 == 0 && row % 2 == 0) || (cell % 2 != 0 && row % 2 != 0))
                {
                    board[cell, row].GetComponent<SpriteRenderer>().color = BoardColor1;
                    colorIndex[cell, row] = board[cell, row].GetComponent<SpriteRenderer>().color;
                    
                } else
                {
                    board[cell, row].GetComponent<SpriteRenderer>().color = BoardColor2;
                    colorIndex[cell, row] = board[cell, row].GetComponent<SpriteRenderer>().color;
                }
                
            }
        }

        ChessPositions();
    }

    void ChessPositions()
    {
        GameObject chess = GameObject.Find("Chess");
        if(chess != null)
        {
            foreach(Transform child in chess.transform)
            {
                int x = child.GetComponent<Chess>().RoundToIntPosition().x;
                int y = child.GetComponent<Chess>().RoundToIntPosition().y;
                
                chessPosition[x, y] = child;
            }
        }
    }

    public static bool  toggleRender = false;
    public static void RenderValidMoves()
    {

        if (!toggleRender)
        {
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    if (validMoves[x, y])
                    {
                        board[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
                    }
                    else
                    {
                        board[x, y].GetComponent<SpriteRenderer>().color = colorIndex[x, y];
                    }
                }
            }
        }
        else
        {
            chosenChess = null;
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {

                    if (validMoves[x, y])
                    {
                        validMoves[x, y] = false;
                        board[x, y].GetComponent<SpriteRenderer>().color = colorIndex[x, y];
                    }
                }
            }
        }
        toggleRender = !toggleRender;
    }

    public void ClearValidMoves()
    {
        for(int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                validMoves[x, y] = false;
            }
        }
    }

    public Vector2Int RoundToIntPosition(float xPos,float yPos)
    {
        int x = Mathf.RoundToInt(xPos);
        int y = Mathf.RoundToInt(yPos);

        return new Vector2Int(x, y);
    }

}
