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
            Random randomAstroid = new Random();

            List<Rectangle> shots = new List<Rectangle>();
            List<Rectangle> astroid = new List<Rectangle>();

            Raylib.SetTargetFPS(60);



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
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        X += 5f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))  //controlls 
                    {
                        X -= 5f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                        Y -= 5f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                        Y += 5f;
                    }





                    Raylib.ClearBackground(Color.LIGHTGRAY);




                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {


                        shots.Add(new Rectangle(X, Y, 20, 40));


                    }

                    for (int i = 0; i < shots.Count; i++)        // Det som skapar skotten 
                    {
                        Rectangle shot = shots[i];
                        shot.y -= 9;
                        shots[i] = shot;

                        Raylib.DrawRectangleRec(shot, Color.RED);
                    }

                    shots.RemoveAll(shot => shot.y < 0);




                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {


                        astroid.Add(new Rectangle(X, Y, 20, 40));


                    }



                    for (int i = 0; i < astroid.Count; i++)
                    {
                        Rectangle astroid = astroids[i];
                        astroid.y -= 9;
                        astroids[i] = astroid;

                        Raylib.DrawRectangleRec(astroid, Color.RED);
                    }







                    Raylib.DrawRectangle((int)X, (int)Y, 50, 70, Color.GREEN);
                    Raylib.DrawRectangle((int)X + 35, (int)Y + 50, 20, 25, Color.RED);
                    Raylib.DrawRectangle((int)X - 7, (int)Y + 50, 20, 25, Color.RED);  //Ritar ut spelaren
                    Raylib.DrawRectangle((int)X + 15, (int)Y + 10, 20, 25, Color.BLUE);
                    score = score + 100f;
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
