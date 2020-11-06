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
            float score = 0;



            Raylib.InitWindow(1200, 800, "bra spel");
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                if (gamestate == "menu")
                {
                    life = 3;
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
                    Raylib.DrawRectangle((int)X, (int)Y, 50, 70, Color.GREEN);
                    Raylib.DrawRectangle((int)X + 35, (int)Y + 50, 20, 25, Color.RED);
                    Raylib.DrawRectangle((int)X - 5, (int)Y + 50, 20, 25, Color.RED);
                    Raylib.DrawRectangle((int)X + 15, (int)Y + 10, 20, 25, Color.BLUE);
                    score = score + 0.01f;
                    Raylib.DrawText("Score: " + score, 20, 20, 40, Color.PINK);

                    if (life <= 0)
                    {
                        gamestate = "gameover";

                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        gamestate = "gameover";
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_O))
                    {
                        life = life - 1;


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
