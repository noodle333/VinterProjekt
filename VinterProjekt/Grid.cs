using System;
using System.Collections.Generic;
using Raylib_cs;


public class Grid
{
    public int time;
    // public List<Piece> deadPieceList = new List<Piece>();
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

    int gridMaxX, gridMaxY;
    public Grid()
    {
        gridMaxX = gridArr.GetLength(1);
        gridMaxY = gridArr.GetLength(0);
    }
    public void Update(Piece p)
    {
        for (int i = 0; i < gridMaxY; i++)
        {
            for (int j = 0; j < gridMaxX; j++)
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
        CheckClearRow();
    }

    public void CheckClearRow()
    {
        //1 => 0
        for (int i = 0; i < gridMaxY; i++)
        {
            for (int j = 0; j < gridMaxX; j++)
            {
                if (gridArr[i, j] == 0)
                {
                    break;
                }
                else if (j == gridMaxX - 1)
                {
                    ClearRow(i);
                }
            }
        }
    }

    public void ClearRow(int row)
    {
        for (int i = 0; i < gridMaxX; i++)
        {
            gridArr[row, i] = 0;
        }
    }

    public bool GridCollision(Piece p)
    {
        if (p.y >= gridMaxX - p.shape.GetLength(0))
        {
            // deadPieceList.Add(p);
            UpdateGrid(p);
            return true;
        }
        return false;
    }

    public bool PieceCollision(Piece currP)
    {
        for (int i = 0; i < gridMaxX; i++)
        {
            for (int j = 0; j < gridMaxY; j++)
            {
                if (gridArr[j, i] == 2)
                {
                    if (gridArr[j + 1, i] == 1)
                    {
                        // deadPieceList.Add(currP);
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
        // for (int i = 0; i < deadPieceList.Count; i++)
        // {
        //     deadPieceList[i].DrawPiece();
        // }
        for (int i = 0; i < gridMaxY; i++)
        {
            for (int j = 0; j < gridMaxX; j++)
            {
                if (gridArr[i, j] == 1)
                {
                    Raylib.DrawRectangle(i * 32 + 200, j * 32 + 200, 32, 32, Color.GRAY);
                }
            }
        }
    }

    public bool IsRightPositionValid()
    {
        for (int i = 0; i < gridMaxX; i++)
        {
            for (int j = 0; j < gridMaxY; j++)
            {
                if (gridArr[j, i] == 2)
                {
                    if (gridArr[j, i + 1] == 1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public bool IsLeftPositionValid()
    {
        for (int i = 0; i < gridMaxX; i++)
        {
            for (int j = 0; j < gridMaxY; j++)
            {
                if (gridArr[j, i] == 2)
                {
                    if (gridArr[j, i - 1] == 1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

}
