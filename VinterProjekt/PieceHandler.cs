using System;
using System.Collections.Generic;

public class PieceHandler
{
    private Dictionary<string, int[,]> pieceList = new Dictionary<string, int[,]>();
    Random gen = new Random();

    //CREATES SHAPE FOR ALL PIECES
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

        Piece ranPiece;

        if (gen.Next(0, 10) == 1)
        {
            ranPiece = new Piece(6, 0, arr[gen.Next(arr.Count)]);
        }
        else
        {
            ranPiece = new SpecialPiece(6, 0, arr[gen.Next(arr.Count)]);
        }

        return ranPiece;
    }
}
