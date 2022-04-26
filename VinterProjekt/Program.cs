using System;
using Raylib_cs;

PieceHandler ph = new PieceHandler();
Grid grid = new Grid();

Raylib.InitWindow(800, 1000, "TETRIS");
Raylib.SetTargetFPS(60);

Piece currentPiece = ph.GetRandomPiece();

//TODO TRY CATCH ON KILLPIECE (GRID COLLISION SHOULD NOT BE HANDELED IN PIECE)

while (!Raylib.WindowShouldClose())
{
    currentPiece.Movement(grid);
    grid.Update(currentPiece);
    //CREATE NEW PIECE UPON DEATH OF A PIECE
    if (grid.PieceShouldDie(currentPiece))
    {
        currentPiece = ph.GetRandomPiece();
    }

    //GRAPHICS
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawRectangle(200, 200, 416, 640, Color.WHITE);
    currentPiece.DrawPiece();
    grid.DrawDeadPieces();
    Raylib.EndDrawing();
}

