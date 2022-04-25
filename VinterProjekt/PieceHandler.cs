using System;
using System.Collections.Generic;

public class PieceHandler
{
    private Dictionary<string, int[,]> pieceList = new Dictionary<string, int[,]>();
    Random gen = new Random();

    public PieceHandler()
    {
        pieceList.Add("I", new int[,]
        {
            {1},
            {1},
            {1},
            {1}
        });
        pieceList.Add("L", new int[,]
        {
            {1, 0},
            {1, 0},
            {1, 1}
        });
        pieceList.Add("J", new int[,]
        {
            {0, 1},
            {0, 1},
            {1, 1}
        });
        pieceList.Add("S", new int[,]
        {
            {0, 1, 1},
            {1, 1, 0}
        });
        pieceList.Add("Z", new int[,]
        {
            {1, 1, 0},
            {0, 1, 1}
        });
        pieceList.Add("O", new int[,]
        {
            {1, 1},
            {1, 1}
        });
        pieceList.Add("T", new int[,]
        {
            {1, 1, 1},
            {0, 1, 0}
        });
    }

    public Piece GetRandomPiece()
    {
        List<int[,]> arr = new List<int[,]>(pieceList.Values);

        Piece ranPiece = new Piece(6, 0, arr[gen.Next(arr.Count)]);

        return ranPiece;
    }
}
