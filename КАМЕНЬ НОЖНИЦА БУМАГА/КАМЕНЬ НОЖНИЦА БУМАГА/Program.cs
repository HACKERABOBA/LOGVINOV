using System;

namespace КАМЕНЬ_НОЖНИЦА_БУМАГА
{
    namespace ConsoleApplication1
    {
        class CInterface  //класс отрисовки интерфеса
        {
            public string name;
            public string Title;
            public string Query;
            public string[] face;
            public CInterface()
            {
                Title = "Игра: камень-ножницы-бумага";
                Query = "Нажмите любую клавишу чтобы повторить игру или Esc, чтобы выйти...";
                face = new string[21];
                face[0] = " -----------------------------------------------------------";
                face[1] = "|           Игра: камень ножницы бумага                      |";
                face[2] = " -----------------------------------------------------------";
                face[3] = "| Введите слово: камень, ножницы или бумага..                |";
                face[4] = "|            Ваш ход     vs     Компьютер                    |";
                face[5] = "|                                                            |";
                face[6] = "|                                                            |";
                face[7] = "|                                                            |";
                face[8] = "|                                                            |";
                face[9] = "|                                                            |";
                face[10] = "|                                                            |";
                face[11] = "|                                                            |";
                face[12] = "|                                                            |";
                face[13] = "|                                                            |";
                face[14] = "|                                                            |";
                face[15] = "|                                                            |";
                face[16] = "|                                                            |";
                face[17] = "|           © 2021 VLADIMIR                       |";
                face[18] = " ------------------------------------------------------------";
                face[19] = "|                                                            |";
                face[20] = " ------------------------------------------------------------";
            }
            public void draw()  //функция рисования пустого поля
            {
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                for (int i = 0; i <= 20; i++)
                {
                    Console.WriteLine(face[i]);
                };

            }
        }

        class CObject
        {
            public string[] obj = { "камень", "ножницы", "бумага" };
            public string user = null;
        }

        class Program
        {
            static void Main(string[] args)
            {
                CInterface iFace = new CInterface();
                Console.Title = iFace.Title;
                Console.ForegroundColor = ConsoleColor.Yellow;

                ConsoleKeyInfo keyCode = new ConsoleKeyInfo(); //начинаем обрабатывать нажатия клавиш

                CObject game = new CObject();

                while (keyCode.Key != ConsoleKey.Escape)
                {

                    Console.Clear();
                    iFace.draw();
                    Console.SetCursorPosition(13, 6);
                    game.user = Console.ReadLine();
                    Random rand = new Random();
                    int i = rand.Next(3);
                    Console.SetCursorPosition(33, 6);
                    Console.Write(game.obj[i]);
                    Console.SetCursorPosition(21, 10);
                    switch (game.user)
                    {
                        case "камень":
                            if (game.obj[i] == "камень")
                            {
                                Console.Write("Ничья...");
                            }
                            if (game.obj[i] == "ножницы")
                            {
                                Console.Write("Вы победили..");
                            }
                            if (game.obj[i] == "бумага")
                            {
                                Console.Write("Вы проиграли...");
                            }
                            break;

                        case "ножницы":
                            if (game.obj[i] == "камень")
                            {
                                Console.Write("Вы проиграли...");
                            }
                            if (game.obj[i] == "ножницы")
                            {
                                Console.Write("Ничья..");
                            }
                            if (game.obj[i] == "бумага")
                            {
                                Console.Write("Вы победили...");
                            }
                            break;

                        case "бумага":
                            if (game.obj[i] == "бумага")
                            {
                                Console.Write("Ничья...");
                            }
                            if (game.obj[i] == "ножницы")
                            {
                                Console.Write("Вы проиграли..");
                            }
                            if (game.obj[i] == "камень")
                            {
                                Console.Write("Вы победили...");
                            }
                            break;

                        default:
                            {
                                Console.SetCursorPosition(7, 10);
                                Console.Write("Вы набрали неправильно слово. Попробуйте заново.");
                            }
                            break;
                    }


                    Console.SetCursorPosition(3, 19);
                    Console.WriteLine("Для повтора нажмите любую клавишу. Еsc - выход");
                    keyCode = Console.ReadKey(true);

                };

            }
        }
    }
}

