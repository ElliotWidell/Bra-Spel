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
            float X = 600;
            float Y = 500;
            float score = 0;
            Random randomAstroid = new Random();
            Random astroidPos = new Random();



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
                        X += 6f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))  //controlls 
                    {
                        X -= 6f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                        Y -= 6f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                        Y += 6f;
                    }





                    Raylib.ClearBackground(Color.BLACK);


                    int aXPos = astroidPos.Next(1200);

                    int r = randomAstroid.Next(100);
                    if (r == 1)
                    {
                        astroid.Add(new Rectangle(aXPos, 0, 50, 50));
                    }


                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {


                        shots.Add(new Rectangle(X + 15, Y, 20, 40));


                    }

                    for (int i = 0; i < shots.Count; i++)        // Det som skapar skotten 
                    {
                        Rectangle shot = shots[i];
                        shot.y -= 9;
                        shots[i] = shot;

                        Raylib.DrawRectangleRec(shot, Color.RED);
                    }

                    shots.RemoveAll(shot => shot.y < 0);






                    for (int i = 0; i < astroid.Count; i++)
                    {
                        Rectangle a = astroid[i];               //skapar astroider
                        a.y += 5;
                        astroid[i] = a;

                        Raylib.DrawRectangleRec(a, Color.GRAY);
                    }














                    Raylib.DrawRectangle((int)X, (int)Y, 50, 70, Color.LIGHTGRAY);
                    Raylib.DrawRectangle((int)X + 35, (int)Y + 50, 20, 25, Color.LIGHTGRAY);
                    Raylib.DrawRectangle((int)X - 7, (int)Y + 50, 20, 25, Color.LIGHTGRAY);  //Ritar ut spelaren
                    Raylib.DrawRectangle((int)X + 15, (int)Y + 10, 20, 25, Color.BLUE);
                    Raylib.DrawRectangle((int)X - 4, (int)Y + 74, 15, 12, Color.ORANGE);
                    Raylib.DrawRectangle((int)X + 38, (int)Y + 74, 15, 12, Color.ORANGE);
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
                    Raylib.DrawText("Game Over", 300, 150, 120, Color.DARKBLUE);
                    Raylib.DrawText("Your Score: " + score, 230, 350, 100, Color.DARKBLUE);   //game over skärmen
                    Raylib.EndDrawing();

                }


            }
        }
    }
}
