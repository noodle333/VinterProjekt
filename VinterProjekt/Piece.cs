using System;
using Raylib_cs;

public class Piece
{
    public int x, y;
    public int width, height;
    public int[,] shape;
    public int shapeXLength, shapeYLength;
    public Rectangle rec;

    public Piece(int x, int y, int[,] shape)
    {
        this.x = x;
        this.y = y;
        this.shape = shape;

        shapeXLength = this.shape.GetLength(1);
        shapeYLength = this.shape.GetLength(0);
    }

    public void Movement(Grid grid)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_A) && x > 0 && grid.IsOffsetPositionValid(-1, 0))
        {
            x -= 1;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D) && x < 13 - shapeXLength && grid.IsOffsetPositionValid(1, 0)) //&& grid.IsPositionValid())
        {
            x += 1;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_S)) //is valid?
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
