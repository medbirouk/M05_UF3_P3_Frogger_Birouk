
//NOMBRE : MOHAMED RACHID BIROUK
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            Console.CursorVisible = false;
            Console.SetWindowSize(Utils.MAP_WIDTH, Utils.MAP_HEIGHT);
            

            Player player = new Player();
            List<Lane> lanes = new List<Lane>();

            lanes.Add(new Lane(6,false,ConsoleColor.DarkGreen,false, false, 0f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(5, false, ConsoleColor.Black, true, false, 0.3f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(4, false, ConsoleColor.Black, true, false, 0.3f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(3, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, true, false, 0.3f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(1, true, ConsoleColor.DarkBlue, true, false, 0.3f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charLogs, Utils.colorsLogs.ToList()));

            
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;
            Vector2Int dir = Vector2Int.zero;

            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            dir.y = -1;
                            break;
                        case ConsoleKey.DownArrow:
                            dir.y = 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            dir.x = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            dir.x = 1;
                            break;
                        default:
                            break;
                    }
                }

                gameState = player.Update(dir, lanes);
                foreach (Lane lane in lanes)
                {
                    lane.Update();
                }

                
                Console.Clear();
                
                foreach (Lane lane in lanes)
                {
                    lane.Draw();
                }
                player.Draw(lanes);


                dir = Vector2Int.zero;

                TimeManager.NextFrame();
                
            }

           
            Console.SetCursorPosition(Utils.MAP_WIDTH / 2 - 4, Utils.MAP_HEIGHT / 2);
            if (gameState == Utils.GAME_STATE.WIN)
            {
                Console.WriteLine("YOU WIN!");
            }
            else
            {
                Console.WriteLine("YOU LOSE");
            }




        }
    }
}

