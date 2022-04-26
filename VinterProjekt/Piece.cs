using System;
using Raylib_cs;

public class Piece
{
    public int x, y;
    public int[,] shape;
    public int shapeXLength, shapeYLength;

    public Piece(int x, int y, int[,] shape)
    {
        //ASSIGNS VALUES FOR PIECE
        this.x = x;
        this.y = y;
        this.shape = shape;

        shapeXLength = this.shape.GetLength(1);
        shapeYLength = this.shape.GetLength(0);
    }

    public void Movement(Grid grid)
    {
        //CHECKS IF PIECE IS IN BOUNDS OF GRID AND IF THE SPACE IN THE DIRECTION IS UNOCCUPIED
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_A) && x > 0 && grid.IsOffsetPositionValid(-1, 0))
        {
            x -= 1;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D) && x < 13 - shapeXLength && grid.IsOffsetPositionValid(1, 0))
        {
            x += 1;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
        {
            y += 1;
        }
    }

    public void DrawPiece()
    {
        for (int i = 0; i < shapeYLength; i++)
        {
            for (int j = 0; j < shapeXLength; j++)
            {
                if (shape[i, j] == 1)
                {
                    Raylib.DrawRectangle(x * 32 + 200 + j * 32, y * 32 + 200 + i * 32, 32, 32, Color.SKYBLUE);
                }
            }
        }
    }
}
