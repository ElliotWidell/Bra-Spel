using System;
using Raylib_cs;
using System.Collections.Generic;

namespace grafik
{
    class Program
    {

        static void Main(string[] args)
        {
            string gamestate = "menu";  // Det som bestämer vilken stat mitt spel är som menu, ingame eller gameover
            float life = 3;
            float X = 0;
            float Y = 0;
            float score = 0;
            float astroidsOnScreen = 0;
            float shotX = 0;
            float shotY = 0;
            Random randomAstroid = new Random();



            Raylib.InitWindow(1200, 800, "bra spel");
            while (!Raylib.WindowShouldClose())
            {

                if (gamestate == "menu")
                {
                    Raylib.BeginDrawing();
                    life = 3;

                    Raylib.ClearBackground(Color.LIGHTGRAY);
                    Raylib.DrawText("Bra spel", 350, 150, 120, Color.DARKBLUE);  // Menu
                    Raylib.DrawText(gamestate, 200, 10, 120, Color.DARKBLUE);

                    Raylib.DrawText("Press Space to play", 300, 650, 60, Color.DARKBLUE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {

                        gamestate = "ingame";

                    }
                    Raylib.EndDrawing();
                }

                else


                if (gamestate == "ingame")
                {
                    Raylib.BeginDrawing();
                    Raylib.DrawText(gamestate, 0, 0, 120, Color.DARKBLUE);
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        X += 0.3f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))  //controlls 
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





                    Raylib.ClearBackground(Color.LIGHTGRAY);

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        shotX = X;
                        shotY = Y;


                        while (shotY > 0)
                        {
                            shotY -= 0.3f;
                            Raylib.DrawRectangle((int)shotX, (int)shotY, 20, 40, Color.PURPLE);



                        }

                        List<string> Astroids = new List<string>() { "bigAstroid", "mediumAstroid", "smallAstroid" };


                        Circle bigAstroidmold = new Circle
                    }
                    if (astroidsOnScreen < 15)
                    {



                    }
                    Raylib.DrawRectangle((int)X, (int)Y, 50, 70, Color.GREEN);
                    Raylib.DrawRectangle((int)X + 35, (int)Y + 50, 20, 25, Color.RED);
                    Raylib.DrawRectangle((int)X - 7, (int)Y + 50, 20, 25, Color.RED);  //Ritar ut spelaren
                    Raylib.DrawRectangle((int)X + 15, (int)Y + 10, 20, 25, Color.BLUE);
                    score = score + 0.01f;
                    Raylib.DrawText("Score: " + score, 20, 20, 40, Color.PINK);

                    if (life <= 0)
                    {
                        gamestate = "gameover";  //Om jag får 0 eller mindre liv så hamnar man i game over skärmen

                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        gamestate = "gameover";
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_O))
                    {
                        life = life - 1;


                    }
                    Raylib.EndDrawing();

                }
                else
                if (gamestate == "gameover")
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.GRAY);
                    Raylib.DrawText("Game Over", 300, 150, 120, Color.DARKBLUE);   //game over skärmen
                    Raylib.EndDrawing();

                }


            }
        }
    }
}
