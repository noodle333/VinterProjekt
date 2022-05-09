using System;
using Raylib_cs;


public class SpecialPiece : Piece
{

    public SpecialPiece(int x, int y, int[,] shape) : base(x, y, shape)
    {
        pieceC = Color.GOLD;

    }
}
