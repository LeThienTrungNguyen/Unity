using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] Vector3Int mousePosition;
    public static Transform[,] board;
    public static Transform[,] chessPositions;
    public static bool[,] validMoves;
    public Chess[] chesses;
    public Transform chessPrefab;
    private void Awake()
    {
        height = 8;
        width = 8;
        board = new Transform[width, height];
        chessPositions = new Transform[width, height];
        validMoves = new bool[width, height];
        InitBoard();
        InitChess();
    }

    private void Update()
    {
        HoverUnit();
        OnClick();
        RenderValidMoves(true);
    }

    public void RenderValidMoves(bool allow)
    {
        if (allow)
        {
            for (int c = 0; c < width; c++)
            {
                for (int r = 0; r < height; r++)
                {
                    if (validMoves[c, r])
                    {
                        board[c, r].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }
        } else
        {
            for (int c = 0; c < width; c++)
            {
                for (int r = 0; r < height; r++)
                {
                    if (validMoves[c, r])
                    {
                        board[c, r].GetComponent<SpriteRenderer>().color = Color.red;
                    } else
                    {
                        if((c % 2 == 0 && r % 2 == 0)|| (c % 2 != 0 && r % 2 != 0))
                        {
                            board[c, r].GetComponent<SpriteRenderer>().color = Color.white;
                        } else
                        {
                            board[c, r].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                    }
                }
            }
        }
    }

    public static Transform chosenChess;

    void OnClick()
    {
        if (Input.GetMouseButtonDown(0) && CheckMouseInBoard())
        {
            int x = GetMousePosition().x;
            int y = GetMousePosition().y;
            if (chosenChess != null && validMoves[x,y])
            {
                if (chessPositions[x, y] != null)
                {
                    if(chesses[FindChessIndex(x, y)].chessTeam != chesses[FindChessIndex((int)chosenChess.position.x, (int)chosenChess.position.y)].chessTeam)
                    {
                        //chesses[FindChessIndex(x, y)].position = new Vector2Int(-1, 0);
                        Destroy(chessPositions[x, y].gameObject);
                        Debug.Log(1);
                    }
                }
            }
            if ((!validMoves[x, y] && chessPositions[x, y] != null) || (!validMoves[x, y] && chessPositions[x, y] == null))
            {
                ClearValidMoves();
                chosenChess = null;
            } else
            {
                
                int index = FindChessIndex((int)chosenChess.position.x, (int)chosenChess.position.y);
                if(index != -1)
                {
                    chesses[index].position.x = x;
                    chesses[index].position.y = y;
                }
                chessPositions[(int)chosenChess.position.x, (int)chosenChess.position.y] = null;
                chosenChess.position = mousePosition;
                chessPositions[x, y] = chosenChess;

                
                ClearValidMoves();
            }

            

            if (chessPositions[x, y] != null)
            {
                chosenChess = chessPositions[x, y];
                int index = FindChessIndex(x, y);
                if (index >=0)
                {
                    switch (chesses[index].chessType)
                    {
                        case Chess.ChessType.King: chesses[index].King(); break;
                        case Chess.ChessType.Queen: chesses[index].Queen(); break;
                        case Chess.ChessType.Bishop: chesses[index].Bishop(); break;
                        case Chess.ChessType.Knight: chesses[index].Knight(); break;
                        case Chess.ChessType.Rook: chesses[index].Rook(); break;
                        case Chess.ChessType.Pawn: chesses[index].Pawn(); break;
                        default: break;
                    }
                }
            }
        }
    }
    void ClearValidMoves()
    {
        for(int c = 0; c < width; c++)
        {
            for (int r = 0; r < height; r++)
            {
                validMoves[c, r] = false;
            }
        }
    }
    public int FindChessIndex(int x,int y)
    {

        for(int i = 0; i < chesses.Length; i++)
        {
            //Debug.Log(chesses[i].position.x +" "+ chesses[i].position.y + " "+x+ " "+ y);
            if (chesses[i].position.x == x && chesses[i].position.y == y)
            {
                return i;
            }
        }
        
        return -1;
    }

    void HoverUnit()
    {
        if (CheckMouseInBoard())
        {
            for(int c=0;c< width; c++)
            {
                for(int r = 0; r < height; r++)
                {
                    
                    if (board[c,r].position.x == GetMousePosition().x && board[c, r].position.y == GetMousePosition().y)
                    {
                        board[c, r].GetComponent<SpriteRenderer>().color = Color.cyan;
                    } else
                    {
                        if((c % 2 == 0 && r % 2 == 0)|| (c % 2 != 0 && r % 2 != 0))
                        {
                            board[c, r].GetComponent<SpriteRenderer>().color = Color.white;
                        } else
                        {
                            board[c, r].GetComponent<SpriteRenderer>().color = Color.gray;
                        }
                    }
                }
            }
        }
    }

    public Transform boardIndex;
    void InitBoard()
    {
        for(int c = 0;c < width; c++)
        {
            for(int r = 0;r < height; r++)
            {
                board[c, r] = Instantiate(boardIndex, new Vector3(c, r, transform.position.z), transform.rotation, transform);
                if((c % 2 == 0 && r % 2 == 0) || (c % 2 != 0 && r % 2 != 0))
                {
                    board[c, r].GetComponent<SpriteRenderer>().color = Color.white;
                } else
                {
                    board[c, r].GetComponent<SpriteRenderer>().color = Color.gray;
                }
            }
        }
    }
    void InitChess()
    {
        for(int count = 1;count < chesses.Length; count++)
        {
            int x = chesses[count].position.x;
            int y = chesses[count].position.y;
            chessPositions[x, y] = Instantiate(chessPrefab, new Vector3Int(x, y, -1), transform.rotation, transform);
            chessPositions[x, y].GetComponent<SpriteRenderer>().sprite = chesses[count].avatar;
            chessPositions[x, y].name = chesses[count].chessType.ToString() + chesses[count].chessTeam.ToString();
            
        }
    }

    public Vector3Int GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = RoundToInt(worldMousePosition.x, worldMousePosition.y);
        return mousePosition;
    }

    Vector3Int RoundToInt(float x,float y)
    {
        return new Vector3Int(Mathf.RoundToInt(x), Mathf.RoundToInt(y));
    }

    public bool CheckMouseInBoard()
    {
        int x = GetMousePosition().x;
        int y = GetMousePosition().y;
        return (x >= 0 && x <= width && y >= 0 && y <= height) ? true : false;
    }
}
