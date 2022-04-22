using System;
using Raylib_cs;

PieceHandler ph = new PieceHandler();
Grid grid = new Grid();

Raylib.InitWindow(800, 1000, "TETRIS");
Raylib.SetTargetFPS(60);

Piece currentPiece = ph.GetRandomPiece();

//TODO POLYMORFI, IF GRIDARR 1 == CEILING, LOSE. CLEAR ROW 

while (!Raylib.WindowShouldClose())
{
    // grid.PrintArray();
    // grid.DrawGrid();
    currentPiece.Movement(grid);
    grid.Update(currentPiece);
    if (grid.PieceShouldDie(currentPiece))
    {
        currentPiece = ph.GetRandomPiece();
    }


    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawRectangle(200, 200, 416, 640, Color.WHITE);
    currentPiece.DrawPiece();
    grid.DrawDeadPieces();
    Raylib.EndDrawing();
}

