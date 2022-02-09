using System;
using System.Collections.Generic;
using Raylib_cs;


public class Grid
{
    public int time;
    public List<Piece> deadPieceList = new List<Piece>();
    //0 = unoccupied space, 1 = occupied space, 2 = temporary occupied space
    int[,] gridArr = new int[,] {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

    };

    public void Update(Piece p)
    {
        for (int i = 0; i < gridArr.GetLength(0); i++)
        {
            for (int j = 0; j < gridArr.GetLength(1); j++)
            {
                if (gridArr[i, j] == 2)
                {
                    gridArr[i, j] = 0;
                }
            }
        }
        for (int i = 0; i < p.shape.GetLength(0); i++)
        {
            for (int j = 0; j < p.shape.GetLength(1); j++)
            {
                if (p.shape[i, j] == 1)
                {
                    gridArr[p.y + i, p.x + j] = 2;
                }
            }
        }

        for (int i = 0; i < gridArr.GetLength(0); i++)
        {
            for (int j = 0; j < gridArr.GetLength(1); j++)
            {
                Console.Write(gridArr[i, j]);
            }
            Console.WriteLine();
        }

        time++;
        if (time == 30)
        {
            p.y++;
            time = 0;
        }
    }

    public void UpdateGrid(Piece p)
    {
        for (int i = 0; i < p.shape.GetLength(0); i++)
        {
            for (int j = 0; j < p.shape.GetLength(1); j++)
            {
                if (p.shape[i, j] == 1)
                {
                    gridArr[p.y + i, p.x + j] = 1;
                }
            }
        }
    }

    public bool GridCollision(Piece p)
    {
        if (p.y >= gridArr.GetLength(0) - p.shape.GetLength(0))
        {
            deadPieceList.Add(p);
            UpdateGrid(p);
            return true;
        }
        return false;
    }

    public bool PieceCollision(Piece currP)
    {
        for (int i = 0; i < gridArr.GetLength(0); i++)
        {
            for (int j = 0; j < gridArr.GetLength(1); j++)
            {
                if (gridArr[i, j] == 2)
                {
                    if (gridArr[i + 1, j] == 1)
                    {
                        deadPieceList.Add(currP);
                        UpdateGrid(currP);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void DrawDeadPieces()
    {
        for (int i = 0; i < deadPieceList.Count; i++)
        {
            deadPieceList[i].DrawPiece();
        }
    }

    // public void DrawGrid()
    // {
    //     for (int i = 0; i < gridArr.GetLength(0); i++)
    //     {
    //         for (int j = 0; j < gridArr.GetLength(1); j++)
    //         {
    //             Raylib.DrawRectangle(x + j * 32, y + i * 32, 30, 30, Color.LIGHTGRAY);
    //         }
    //     }
    // }
}
