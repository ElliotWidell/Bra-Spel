using System;
using Raylib_cs;

namespace grafik
{
    class Program
    {
        static void Main(string[] args)
        {
            string gamestate = "menu";
            float life = 3;
            float X = 0;
            float Y = 0;

            Raylib.InitWindow(1200, 800, "bra spel");
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                if (gamestate == "menu")
                {

                    Raylib.ClearBackground(Color.LIGHTGRAY);
                    Raylib.DrawText("Bra spel", 350, 150, 120, Color.DARKBLUE);

                    Raylib.DrawText("Press Space to play", 300, 650, 60, Color.DARKBLUE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {

                        gamestate = "ingame";
                    }

                }
                if (gamestate == "ingame")
                {

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        X += 0.3f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                    {
                        X -= 0.3f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                        Y -= 0.3f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                        Y += 0.3f;
                    }

                    Raylib.ClearBackground(Color.WHITE);
                    Raylib.DrawRectangle((int)X, (int)Y, 50, 50, Color.GREEN);

                    if (life <= 0)
                    {
                        gamestate = "gameover";

                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        gamestate = "gameover";
                    }
                }
                if (gamestate == "gameover")
                {
                    Raylib.ClearBackground(Color.LIGHTGRAY);
                    Raylib.DrawText("Game Over", 300, 150, 120, Color.DARKBLUE);

                }
                Raylib.EndDrawing();



            }
        }
    }
}
