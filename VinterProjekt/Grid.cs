using System;
using System.Collections.Generic;
using Raylib_cs;


public class Grid
{
    private int time;
    private int[,] gridArr = new int[,] {
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


    private int gridXLength, gridYLength;

    public Grid()
    {
        gridXLength = gridArr.GetLength(1);
        gridYLength = gridArr.GetLength(0);
    }

    public void Update(Piece p)
    {
        for (int y = 0; y < gridYLength; y++)
        {
            for (int x = 0; x < gridXLength; x++)
            {
                if (gridArr[y, x] == 2)
                {
                    gridArr[y, x] = 0;
                }
            }
        }
        for (int y = 0; y < p.shapeYLength; y++)
        {
            for (int x = 0; x < p.shapeXLength; x++)
            {
                if (p.shape[y, x] == 1)
                {
                    gridArr[p.y + y, p.x + x] = 2;
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

    private void KillPiece(Piece p)
    {
        for (int y = 0; y < p.shapeYLength; y++)
        {
            for (int x = 0; x < p.shapeXLength; x++)
            {
                if (p.shape[y, x] == 1)
                {
                    gridArr[p.y + y, p.x + x] = 1;
                }
            }
        }
        CheckClearRow();
    }

    private void CheckClearRow()
    {
        //1 => 0
        for (int y = 0; y < gridYLength; y++)
        {
            for (int x = 0; x < gridXLength; x++)
            {
                if (gridArr[y, x] == 0)
                {
                    break;
                }
                else if (x == gridXLength - 1)
                {
                    ClearRow(y);
                }
            }
        }
    }

    private void ClearRow(int row)
    {
        for (int x = 0; x < gridXLength; x++)
        {
            gridArr[row, x] = 0;
        }
    }

    public bool PieceShouldDie(Piece p)
    {
        if (GridCollision(p) || !IsOffsetPositionValid(0, 1))
        {
            KillPiece(p);
            return true;
        }
        return false;
    }

    private bool GridCollision(Piece p)
    {
        if (p.y >= gridYLength - p.shapeYLength)
        {
            return true;
        }
        return false;
    }

    public void DrawDeadPieces()
    {
        for (int y = 0; y < gridYLength; y++)
        {
            for (int x = 0; x < gridXLength; x++)
            {
                if (gridArr[y, x] == 1)
                {
                    Raylib.DrawRectangle(x * 32 + 200, y * 32 + 200, 32, 32, Color.GRAY);
                }
            }
        }
    }

    public bool IsOffsetPositionValid(int xOffset, int yOffset)
    {
        for (int y = 0; y < gridYLength; y++)
        {
            for (int x = 0; x < gridXLength; x++)
            {
                if (gridArr[y, x] == 2)
                {
                    if (gridArr[y + yOffset, x + xOffset] == 1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
