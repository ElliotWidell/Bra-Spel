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
            int score = 0;
            Random randomAstroid = new Random();
            Random astroidPos = new Random();
            int difficulty = 100;
            string difficultyText = "Easy";
            float shotTimer = 0;
            float shotTimerMax = 0.5f;
            float outTimerMax = 3;
            float outTimer = 0;

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


                    Raylib.DrawText("Press Space to play", 300, 650, 60, Color.DARKBLUE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {

                        gamestate = "ingame";

                    }
                    Raylib.EndDrawing();
                }


                else if (gamestate == "ingame")
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
                    Raylib.DrawRectangle(20, 400, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(200, 100, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(550, 230, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(1050, 600, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(800, 150, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(90, 650, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(450, 710, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(810, 550, 20, 20, Color.YELLOW);
                    Raylib.DrawRectangle(250, 400, 20, 20, Color.YELLOW);

                    Raylib.DrawText("Health", 1000, 650, 40, Color.WHITE);



                    if (score > 10000 && score < 30000)
                    {
                        difficultyText = "Medium";
                        difficulty = 50;

                    }


                    if (score > 30001 && score < 50000)
                    {
                        difficultyText = "Hard";
                        difficulty = 25;

                    }

                    if (score > 50001 && score < 70000)
                    {
                        difficultyText = "OverKill";        //de olika svårighets graderna som går upp med hur högt score man har
                        difficulty = 15;

                        }

                    if (score > 70001)
                    {
                        difficultyText = "DeathWish";
                        difficulty = 2;

                    }


                    int aXPos = astroidPos.Next(1200);

                    int r = randomAstroid.Next(difficulty);
                    if (r == 1)
                    {
                        astroid.Add(new Rectangle(aXPos, 0, 50, 50));
                    }

                    if (X >= 1200 || Y >= 800 || 0 >= X || 0 >= Y)
                    {
                        outTimer += Raylib.GetFrameTime();
                        Raylib.DrawText("Get Back Or You Will Die!", 260, 300, 60, Color.RED);

                    }

                    if (outTimer >= outTimerMax)
                    {
                        life = 0;        //det som gör att man dör om man är utanför skärmen för länge
                    }

                    shotTimer += Raylib.GetFrameTime();
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotTimer > shotTimerMax)
                    {
                        shotTimer = 0;

                        shots.Add(new Rectangle(X + 15, Y, 20, 40));


                    }

                    for (int i = 0; i < shots.Count; i++)        // Det som skapar skotten 
                    {
                        Rectangle shot = shots[i];      // Det som flyttar skotten
                        shot.y -= 9;
                        shots[i] = shot;

                        Raylib.DrawRectangleRec(shot, Color.RED);
                    }

                    shots.RemoveAll(shot => shot.y < 0);





                    Rectangle playerRec = new Rectangle((int)X, (int)Y, 50, 70);




                    for (int i = 0; i < astroid.Count; i++)
                    {
                        Rectangle a = astroid[i];               //skapar astroider
                        a.y += 5;
                        astroid[i] = a;

                        Raylib.DrawRectangleRec(a, Color.GRAY);
                    }
                    foreach (Rectangle shot in shots)
                    {
                        astroid.RemoveAll(a => Raylib.CheckCollisionRecs(a, shot));
                    }


                    foreach (Rectangle rect in astroid)

                        if (Raylib.CheckCollisionRecs(playerRec, rect))  // Kollar om spelaren åker in i en astroid

                            life--;


                    astroid.RemoveAll(a => Raylib.CheckCollisionRecs(a, playerRec));












                    Raylib.DrawRectangleRec(playerRec, Color.LIGHTGRAY);
                    Raylib.DrawRectangle((int)X + 35, (int)Y + 50, 20, 25, Color.LIGHTGRAY);
                    Raylib.DrawRectangle((int)X - 7, (int)Y + 50, 20, 25, Color.LIGHTGRAY);  //Ritar ut spelaren
                    Raylib.DrawRectangle((int)X + 15, (int)Y + 10, 20, 25, Color.BLUE);
                    Raylib.DrawRectangle((int)X - 4, (int)Y + 74, 15, 12, Color.ORANGE);
                    Raylib.DrawRectangle((int)X + 38, (int)Y + 74, 15, 12, Color.ORANGE);
                    score = score + 10;
                    Raylib.DrawText("Score: " + score, 20, 20, 40, Color.PINK);
                    Raylib.DrawText("Difficulty: " + difficultyText, 750, 20, 40, Color.PINK);


                    if (life == 3)
                    {
                        Raylib.DrawRectangle(1000, 700, 35, 45, Color.RED);
                        Raylib.DrawRectangle(1050, 700, 35, 45, Color.RED);
                        Raylib.DrawRectangle(1100, 700, 35, 45, Color.RED);

                    }
                    if (life == 2)
                    {
                        Raylib.DrawRectangle(1000, 700, 35, 45, Color.RED);
                        Raylib.DrawRectangle(1050, 700, 35, 45, Color.RED);
                        Raylib.DrawRectangle(1100, 700, 35, 45, Color.GRAY);

                    }
                    if (life == 1)
                    {
                        Raylib.DrawRectangle(1000, 700, 35, 45, Color.RED);
                        Raylib.DrawRectangle(1050, 700, 35, 45, Color.GRAY);
                        Raylib.DrawRectangle(1100, 700, 35, 45, Color.GRAY);

                    }

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

                else if (gamestate == "gameover")
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.GRAY);
                    Raylib.DrawText("Game Over", 300, 150, 120, Color.DARKBLUE);
                    Raylib.DrawText("Your Score: ", 270, 300, 100, Color.DARKBLUE);   //game over skärmen
                    Raylib.DrawText(" " + score, 270, 400, 200, Color.RED);
                    Raylib.DrawText("Press Space For Main Menu", 170, 650, 50, Color.RED);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {

                        gamestate = "menu";

                    }
                    Raylib.EndDrawing();
                }
            }

        }


    }
}




