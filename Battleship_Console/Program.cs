using System;
using Battleship_Console;

namespace BattleshipConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Морской бой";
            User User = new User();
            Bot Bot = new Bot();
            bool yes = true;
            while (yes)
            {
                while (true)
                {
                    User.Output(User.Field1);
                    User.Strike();
                    if (User.Win())
                    {
                        break;
                    }
                    Bot.Strike();
                    if (Bot.Win())
                    {
                        break;
                    }
                }
                //0 - пустая клетка, 1 - корабль, 2 - попадание по кораблю, 3 - промах
                Console.SetCursorPosition(30, 1);
                Console.WriteLine("A great game. Wanna play again?(+/-) ");
                Console.SetCursorPosition(30, 1);
                if (Console.ReadLine() != "+")
                {
                    Console.Clear();
                    yes = false;
                }
            }
        }
    }
}