using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chess 
{
    public Vector2Int position;
    public enum ChessType
    {
        King , Queen , Bishop, Knight , Rook , Pawn
    }
    public enum ChessTeam
    {
        White , Black
    }

    public ChessType chessType;
    public ChessTeam chessTeam;

    public Sprite avatar;

    public void King()
    {

    }
    public void Queen()
    {

    }
    public void Bishop()
    {

    }
    public void Knight()
    {

    }
    public void Rook()
    {

    }

    public void Pawn()
    {
        if(chessTeam == ChessTeam.White)
        {
            if(position.y == 7)
            {
                return;
            }
            if (position.y <= 6)
            {
                Board.validMoves[position.x, position.y+1] = true;
            }
            if(Board.chessPositions[position.x, position.y + 1] != null)
            {
                return;
            }
            if (position.y <= 5)
            {
                Board.validMoves[position.x, position.y + 2] = true;
            }
        }
        if (chessTeam == ChessTeam.Black)
        {
            if(position.y == 0)
            {
                return;
            }
            if (position.y >= 1)
            {
                Board.validMoves[position.x, position.y - 1] = true;
            }
            if(Board.chessPositions[position.x, position.y - 1] != null)
            {
                return;
            }
            if (position.y >=0 )
            {
                Board.validMoves[position.x, position.y - 2] = true;
            }
        }
    }

   
}
