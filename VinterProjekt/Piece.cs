using System;
using Raylib_cs;


//TODO Piece x dependant on grid. (x = 2 -> grid[2] then convert on use x *= 32 +)
public class Piece
{
    public int x, y;
    public int width, height;
    public int[,] shape;
    public Rectangle rec;


    public void Movement()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_A) && x > 0)
        {
            x -= 1;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D) && x < 13 - shape.GetLength(1))
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
        //GetLength0 <| GetLength1
        //klura ut längden och höjden av n 2d array.
    }
}
