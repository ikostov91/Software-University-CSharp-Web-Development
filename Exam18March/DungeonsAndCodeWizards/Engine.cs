using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class Engine
    {
        public void Run()
        {
            DungeonMaster dm = new DungeonMaster();
            bool gameOver = false;

            while (true)
            {
                string input = Console.ReadLine();

                //if (string.IsNullOrEmpty(input))
                //{
                //    try set gameOver = true
                //    gameOver = true;
                //}

                if (string.IsNullOrEmpty(input))
                {
                    Console.Write(dm.GetStats());
                    return;
                }

                string[] command = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    switch (command[0])
                    {
                        case "JoinParty":
                            Console.WriteLine(dm.JoinParty(command.Skip(1).ToArray()));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(dm.AddItemToPool(command.Skip(1).ToArray()));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(dm.PickUpItem(command.Skip(1).ToArray()));
                            break;
                        case "UseItem":
                            Console.WriteLine(dm.UseItem(command.Skip(1).ToArray()));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(dm.UseItemOn(command.Skip(1).ToArray()));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(dm.GiveCharacterItem(command.Skip(1).ToArray()));
                            break;
                        case "GetStats":
                            Console.WriteLine(dm.GetStats());
                            break;
                        case "Attack":
                            Console.Write(dm.Attack(command.Skip(1).ToArray()));
                            break;
                        case "Heal":
                            Console.WriteLine(dm.Heal(command.Skip(1).ToArray()));
                            break;
                        case "EndTurn":
                            Console.Write(dm.EndTurn(command.Skip(1).ToArray()));
                            gameOver = dm.IsGameOver();
                            //if (dm.IsGameOver())
                            //{
                            //    Console.Write(dm.GetStats());
                            //    return;
                            //}
                            break;
                        case "IsGameOver":
                            gameOver = dm.IsGameOver();
                            //if (dm.IsGameOver())
                            // {
                            //    Console.Write(dm.GetStats());
                            //    return;
                            //}
                            break;
                    }

                    if (gameOver)
                    {
                        Console.Write(dm.GetStats());
                        return;
                    }
                }
                catch (Exception exception)
                {
                    string exceptionDetails = string.Empty;

                    switch (exception.GetType().Name)
                    {
                        case "ArgumentException":
                            exceptionDetails = "Parameter Error:";
                            break;
                        case "InvalidOperationException":
                            exceptionDetails = "Invalid Operation:";
                            break;
                    }

                    Console.WriteLine($"{exceptionDetails} {exception.Message}");
                }
            }
        }
    }
}
