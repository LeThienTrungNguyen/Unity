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
    // Start is called before the first frame update
    void Start()
    {
        BoardInit();
    }

    // Update is called once per frame
   

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
                Debug.Log($"x = {x}, y = {y}");
                chessPosition[x, y] = child;
            }
        }
    }
}
