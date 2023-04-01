using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    
    public enum ChessType
    {
        King, Queen, Bishop, Knight, Rook, Pawn
    }
    public enum ChessTeam
    {
        White, Black
    }
    public Vector3Int startPoint;


    public ChessType chessType;
    public ChessTeam chessTeam;

    GameObject staticBoard;
    // Start is called before the first frame update
    private void Start()
    {
        staticBoard=GameObject.Find("Board");
        transform.position = startPoint;
        if (Board.chessPosition != null)
        {
            //Board.chessPosition[RoundToIntPosition().x, RoundToIntPosition().y] = transform;
        }

    }
    private void Update()
    {
        
    }


    public Vector2Int RoundToIntPosition()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);

        return new Vector2Int(x, y);
    }

    private void SetValidMoves()
    {
        
        switch (chessType)
        {
            
            case ChessType.Queen: QueenValidMoves();
                break;
            case ChessType.King: KingValidMoves();
                break;
            case ChessType.Bishop: BishopValidMoves();
                break;
            case ChessType.Knight: KnightValidMoves();

                break;
            case ChessType.Rook: RookValidMoves();
                break;
            case ChessType.Pawn: PawnValidMoves();
                break;
        }
    }
    

    [SerializeField]
    public bool isFirstMove = true;

    void KingValidMoves()
    {
        for (int i = 0; i < Board.boardWidth - 1; i++)
        {
            for (int j = 0; j < Board.boardHeight - 1; j++)
            {
                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == 1)
                {
                    Board.validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == 1)
                {
                    Board.validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == -1)
                {
                    Board.validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y - 1] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == -1)
                {
                    Board.validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y - 1] = true;
                }
                if (i - RoundToIntPosition().x == -1)
                {
                    Board.validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y] = true;
                }
                if (i - RoundToIntPosition().x == 1)
                {
                    Board.validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y] = true;
                }
                if (i - RoundToIntPosition().y == 1)
                {
                    Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().y == -1)
                {
                    Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 1] = true;
                }

            }
        }

    }
    void PawnValidMoves()
    {
        if (chessTeam == ChessTeam.White)
        {
            if (isFirstMove)
            {
                Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 2] = true;
                Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 1] = true;
            }
            else
            {
                Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y + 1] = true;
            }
        }
        else
        {
            if (isFirstMove)
            {
                Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 2] = true;
                Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 1] = true;
            }
            else
            {
                Board.validMoves[RoundToIntPosition().x, RoundToIntPosition().y - 1] = true;
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
                    Board.validMoves[RoundToIntPosition().x + 2, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == -2 && j - RoundToIntPosition().y == 1)
                {
                    Board.validMoves[RoundToIntPosition().x - 2, RoundToIntPosition().y + 1] = true;
                }
                if (i - RoundToIntPosition().x == 2 && j - RoundToIntPosition().y == -1)
                {
                    Board.validMoves[RoundToIntPosition().x + 2, RoundToIntPosition().y - 1] = true;
                }
                if (i - RoundToIntPosition().x == -2 && j - RoundToIntPosition().y == -1)
                {
                    Board.validMoves[RoundToIntPosition().x - 2, RoundToIntPosition().y - 1] = true;
                }



                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == 2)
                {
                    Board.validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y + 2] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == 2)
                {
                    Board.validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y + 2] = true;
                }
                if (i - RoundToIntPosition().x == 1 && j - RoundToIntPosition().y == -2)
                {
                    Board.validMoves[RoundToIntPosition().x + 1, RoundToIntPosition().y - 2] = true;
                }
                if (i - RoundToIntPosition().x == -1 && j - RoundToIntPosition().y == -2)
                {
                    Board.validMoves[RoundToIntPosition().x - 1, RoundToIntPosition().y - 2] = true;
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
                Board.validMoves[i, RoundToIntPosition().y] = true;
            }
        }
        // vertical valid moves
        for (int i = 0; i < Board.boardHeight; i++)
        {
            if (i != RoundToIntPosition().y)
            {
                Board.validMoves[RoundToIntPosition().x, i] = true;
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
                    Board.validMoves[i, j] = true;
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
                    Board.validMoves[i, j] = true;
                }
            }
        }
    }
    void RookValidMoves()
    {
        // horizontal valid moves
        for (int i = 0; i < Board.boardWidth; i++)
        {
            if (i != RoundToIntPosition().x)
            {
                Board.validMoves[i, RoundToIntPosition().y] = true;
            }
        }
        // vertical valid moves
        for (int i = 0; i < Board.boardHeight; i++)
        {
            if (i != RoundToIntPosition().y)
            {
                Board.validMoves[RoundToIntPosition().x, i] = true;
            }
        }
    }
    private void OnMouseDown()
    {
        Board.chosenChess = transform;
        SetValidMoves();
        Board.RenderValidMoves();
    }
}
