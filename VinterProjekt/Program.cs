using System;
using Raylib_cs;

Piece p = new Piece();
PieceHandler ph = new PieceHandler();
Grid grid = new Grid();

Raylib.InitWindow(800, 1000, "TETRIS");
Raylib.SetTargetFPS(60);

Piece currentPiece = ph.GetRandomPiece();

while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawRectangle(200, 200, 416, 640, Color.WHITE);
    // grid.DrawGrid();
    currentPiece.DrawPiece();
    currentPiece.Movement();
    grid.Update(currentPiece);

    if (grid.GridCollision(currentPiece))
    {
        currentPiece = ph.GetRandomPiece();
    }

    grid.DrawDeadPieces();
    if (grid.PieceCollision(currentPiece))
    {
        currentPiece = ph.GetRandomPiece();
    }

    Raylib.EndDrawing();
}

