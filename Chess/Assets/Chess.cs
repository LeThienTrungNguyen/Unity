using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    public bool[,] validMoves = new bool[8, 8];
    public enum ChessType
    {
        King, Queen, Bishop, Knight, Rook, Pawn
    }
    public enum ChessTeam
    {
        White, Black
    }
    public Vector3Int startPoint;
    //[SerializeField] Color defaultColor;


    public ChessType chessType;
    public ChessTeam chessTeam;

    // Start is called before the first frame update
    private void Start()
    {
        
        transform.position = startPoint;
        if (Board.chessPosition != null)
        {
            //Board.chessPosition[RoundToIntPosition().x, RoundToIntPosition().y] = transform;
        }
        
    }


    private void Update()
    {
        SetValidMoves();
    }


    public Vector2Int RoundToIntPosition()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);

        return new Vector2Int(x, y);
    }

    private void SetValidMoves()
    {
        ClearValidMoves();

        switch (chessType)
        {
            case ChessType.Queen: QueenValidMoves(); break;
            case ChessType.King: KingValidMoves(); break;
            case ChessType.Bishop: BishopValidMoves(); break;
            case ChessType.Knight: KnightValidMoves(); break;
            case ChessType.Rook: RookValidMoves(); break;
            case ChessType.Pawn: PawnValidMoves(); break;
        }
    }
    void RookValidMoves()
    {
        // horizontal valid moves
        for (int i = 0; i < Board.boardWidth; i++)
        {
            if (i != RoundToIntPosition().x)
            {
                validMoves[i, RoundToIntPosition().y] = true;
            }
        }
        // vertical valid moves
        for (int i = 0; i < Board.boardHeight; i++)
        {
            if (i != RoundToIntPosition().y)
            {
                validMoves[RoundToIntPosition().x, i] = true;
            }
        }
    }

    [SerializeField]
    bool isFirstMove = true;
    void PawnValidMoves()
    {
        if (chessTeam == ChessTeam.White)
        {
            if (isFirstMove)
            {
                validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 2] = true;
                validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 1] = true;
            } else
            {
                validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 1] = true;
            }
        }
        else
        {
            if (isFirstMove)
            {
                validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 2] = true;
                validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 1] = true;
            }
            else 
            {
                validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 1] = true;
            }
        }

    }
    void KnightValidMoves()
    {
        for (int i = 0; i < Board.boardWidth; i++)
        {
            for (int j = 0; j < Board.boardHeight; j++)
            {
                if (i - RoundToIntPosition().x == 2 && j - RoundToIntPosition().y == 1)
                {
                    validMoves[RoundToIntPosition().x + 2, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == -2 && j - RoundToIntPosition().y == 1)
                {
                    validMoves[RoundToIntPosition().x - 2, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == 2 && j - RoundToIntPosition().y == -1)
                {
                    validMoves[RoundToIntPosition().x + 2, RoundToIntPosition().y - 1] = true;
                }
                if (i - RoundToIntPosition().x == -2 && j - RoundToIntPosition().y == -1)
                {
                    validMoves[RoundToIntPosition().x - 2, RoundToIntPosition().y - 1] = true;
                }



                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == 2)
                {
                    validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y + 2] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == 2)
                {
                    validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y + 2] = true;
                }
                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == -2)
                {
                    validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y - 2] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == -2)
                {
                    validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y - 2] = true;
                }
            }
        }
    }

    void QueenValidMoves()
    {
        // horizontal valid moves
        for (int i = 0; i < Board.boardWidth; i++)
        {
            if (i != RoundToIntPosition().x)
            {
                validMoves[i, RoundToIntPosition().y] = true;
            }
        }
        // vertical valid moves
        for (int i = 0; i < Board.boardHeight; i++)
        {
            if (i != RoundToIntPosition().y)
            {
                validMoves[RoundToIntPosition().x, i] = true;
            }
        }
        // diagonal up-right && up-left valid moves
        for (int i = 0; i < Board.boardHeight; i++)
        {
            for (int j = 0; j < Board.boardHeight; j++)
            {
                if ((i != RoundToIntPosition().x && j != RoundToIntPosition().y)
                    && (Mathf.Abs(i - RoundToIntPosition().x)
                        == Mathf.Abs(j - RoundToIntPosition().y)))
                {
                    validMoves[i, j] = true;
                }
            }
        }

    }

    void KingValidMoves()
    {
        for (int i = 0; i < Board.boardWidth - 1; i++)
        {
            for (int j = 0; j < Board.boardHeight - 1; j++)
            {
                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == 1)
                {
                    validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == 1)
                {
                    validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == -1)
                {
                    validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y - 1] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == -1)
                {
                    validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y - 1] = true;
                }
                if (i - RoundToIntPosition().x == -1)
                {
                    validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y] = true;
                }
                if (i - RoundToIntPosition().x == 1)
                {
                    validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y] = true;
                }
                if (i - RoundToIntPosition().y == 1)
                {
                    validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().y == -1)
                {
                    validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 1] = true;
                }

            }
        }

    }

    void BishopValidMoves()
    {
        // diagonal up-right && up-left valid moves
        for (int i = 0; i < Board.boardHeight; i++)
        {
            for (int j = 0; j < Board.boardHeight; j++)
            {
                if ((i != RoundToIntPosition().x && j != RoundToIntPosition().y)
                    && (Mathf.Abs(i - RoundToIntPosition().x)
                        == Mathf.Abs(j - RoundToIntPosition().y)))
                {
                    validMoves[i, j] = true;
                }
            }
        }
    }
    void ClearValidMoves()
    {
        for (int i = 0; i < Board.boardWidth; i++)
        {
            for (int j = 0; j < Board.boardHeight; j++)
            {
                validMoves[i, j] = false;
            }
        }
    }
    
    bool toggleRender = false;
    void RenderValidMoves()
    {


        if (!toggleRender)
        {

            for (int x = 0; x < Board.boardWidth; x++)
            {
                for (int y = 0; y < Board.boardHeight; y++)
                {

                    if (validMoves[x, y])
                    {
                        Board.board[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
                    }
                    else
                    {
                        Debug.Log(Board.colorIndex[x, y].r + "," + Board.colorIndex[x, y].g + "," + Board.colorIndex[x, y].b);
                        Board.board[x, y].GetComponent<SpriteRenderer>().color = Board.colorIndex[x, y];
                    }
                }
            }
        }
        else
        {

            for (int x = 0; x < Board.boardWidth; x++)
            {
                for (int y = 0; y < Board.boardHeight; y++)
                {

                    if (validMoves[x, y])
                    {
                        Board.board[x, y].GetComponent<SpriteRenderer>().color = Board.colorIndex[x, y];
                    }
                }
            }
        }
        toggleRender = !toggleRender;
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse click");
        RenderValidMoves();
    }
}
