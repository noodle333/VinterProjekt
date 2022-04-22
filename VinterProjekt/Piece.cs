using System;
using Raylib_cs;

public class Piece
{
    public int x, y;
    public int width, height;
    public int[,] shape;
    public Rectangle rec;


    public void Movement(Grid grid)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_A) && x > 0 && grid.IsLeftPositionValid())
        {
            x -= 1;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D) && x < 13 - shape.GetLength(1) && grid.IsRightPositionValid()) //&& grid.IsPositionValid())
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
        for (int i = 0; i < shape.GetLength(0); i++)
        {
            for (int j = 0; j < shape.GetLength(1); j++)
            {
                if (shape[i, j] == 1)
                {
                    Raylib.DrawRectangle(x * 32 + 200 + j * 32, y * 32 + 200 + i * 32, 32, 32, Color.SKYBLUE);
                }
            }
        }
    }
}
