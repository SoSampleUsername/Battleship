using System;

namespace Battleship_Console
{
    public class Battleship
    {
        public const int four = 1;
        public const int three = 2;
        public const int two = 3;
        public const int one = 4;
         
        public static string[] str1 = { "р", "е", "с", "п", "у", "б", "л", "и", "к", "а" };
        public static  string[] str2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public int Step = new int();
        public int[] Letter = new int[101];
        public int[] Index = new int[101];
        public int Points = 0;
        public static int Space = 2;
        public int Number = 0;

        public static int[,] BotField = new int[10, 10];
        public int[,] Field1 = new int[10, 10];
        public static int[,] UserField = new int[10, 10];

        public void Output(int[,] Field)
        {
            if (Space > 20)
            {
                Space = 2;
                Console.Clear();
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 0);
                Console.Write(str1[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write(str2[i]);
                Console.SetCursorPosition(2, i + 1);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 1);
                    Part(UserField[i, j]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 13);
                Console.Write(str1[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 14);
                Console.Write(str2[i]);
                Console.SetCursorPosition(2, i + 14);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 14);
                    Part(Field[i, j]);

                }
            }
        }
        public void Part(int a)
        {
            switch (a)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('W');
                    Console.ResetColor();
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("■", Console.BackgroundColor);
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('X');
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('O');
                    Console.ResetColor();
                    break;
            }
        }
        protected void Stroke(int[,] Field, int i, int j)
        {
            int Long = 1;
            int x = j;
            int y = i;
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i - k, j] == 2)
                    {
                        Long++;
                        y--;
                    }
                    if (Field[i - k, j] == 1)
                    {
                        return;
                    }
                    if (Field[i - k, j] == 0 || Field[i - k, j] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i + k, j] == 2)
                    {
                        Long++;
                    }
                    if (Field[i + k, j] == 1)
                    {
                        return;
                    }
                    if (Field[i + k, j] == 0 || Field[i + k, j] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            if (Long > 1)
            {
                for (int k = y - 1; k < y + Long + 1 && k < 10; k++)
                {
                    if (k < 0)
                    {
                        k++;
                    }
                    for (int l = x - 1; l < x + 2 && l < 10; l++)
                    {
                        if (l < 0)
                        {
                            l++;
                        }
                        if (Field[k, l] != 2)
                        {
                            Console.SetCursorPosition(42, 0);
                            Console.Write("Sent him to the bottom!");
                            Field[k, l] = 3;
                            Field1[k, l] = 3;
                        }
                    }
                }
                return;
            }

            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i, j - k] == 2)
                    {
                        Long++;
                        x--;;
                    }
                    if (Field[i, j - k] == 1)
                    {
                        return;
                    }
                    if (Field[i, j - k] == 0 || Field[i, j - k] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i, j + k] == 2)
                    {
                        Long++;                        
                    }
                    if (Field[i, j + k] == 1)
                    {
                        return;
                    }
                    if (Field[i, j + k] == 0 || Field[i, j + k] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            if (Long > 1)
            {
                for (int l = y - 1; l < y + 2 && l < 10; l++)
                {
                    for (int k = x - 1; k < x + Long + 1 && k < 10; k++)
                    {
                        if (k < 0)
                        {
                            k++;
                        }
                        if (l < 0)
                        {
                            l++;
                        }
                        if (Field[l, k] != 2)
                        {
                            Console.SetCursorPosition(42, 0);
                            Console.Write("Sent him to the bottom!");
                            Field[l, k] = 3;
                            Field1[l, k] = 3;
                        }
                    }
                }
                return;
            }

            if (Long == 1)
            {
                for (int k = y - 1; k < y + 2 && k < 10; k++)
                {
                    if (k < 0)
                    {
                        k = 0;
                    }
                    for (int l = x - 1; l < x + 2 && l < 10; l++)
                    {
                        if (l < 0)
                        {
                            l = 0;
                        }
                        if (Field[k, l] != 2)
                        {
                            Console.SetCursorPosition(42, 0);
                            Console.Write("Sent him to the bottom!");
                            Field[k, l] = 3;
                            Field1[k, l] = 3;
                        }
                    }
                }
            }
        }
    }

}
