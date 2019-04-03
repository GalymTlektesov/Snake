using System;
using System.Threading;
using System.Media;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public static object locker = new object();


        static void Main(string[] args)
        {
            int speed = 99;
            int score = 0;
            int record = 0;
            Console.SetBufferSize(80, 25);

            record = Properties.Settings.Default.record;

            Walls walls = new Walls(80, 25);
            walls.Draw();

            //Отрисовка точек
            Console.ForegroundColor = ConsoleColor.Yellow;
            Point p = new Point(4, 5, '*');


            Console.ForegroundColor = ConsoleColor.Green;
            Direction direction = Direction.RIGHT;
            Snake snake = new Snake(p, 4, direction);
            snake.Drow();

            FoodCreator foodcreator = new FoodCreator(77, 23, '$');
            Point food = foodcreator.CreateFood();
            food.Draw();


            BackGroundMusicAsync();

            while (true)
            {
                if (score > record)
                    record = score;

                SaveAsync(record);

                Console.SetCursorPosition(10, 24);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Tne best {0}", record);


                Console.SetCursorPosition(70, 24);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(score + " $ ");


                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    snake.GameOver();
                    food.Clear();
                    food = foodcreator.CreateFood();
                    food.Draw();
                    score -= score;
                    speed = 100;
                }


                if (snake.Eat(food))
                {
                    food = foodcreator.CreateFood();
                    food.Draw();
                    speed -= 3;
                    score += 1;
                }


                else
                {
                    snake.Move();
                }

                if (speed == 0)
                {
                    speed += 3;
                }
                Thread.Sleep(speed);


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }





        static void BackGroundMusic()
        {
            SoundPlayer backgroundMusic = new SoundPlayer("backgroundmus.wav");
            backgroundMusic.LoadAsync();
            backgroundMusic.PlayLooping();
        }

        static async Task BackGroundMusicAsync()
        {
            await Task.Run(() => BackGroundMusic());
        }



        static async Task SaveAsync(int record)
        {
            await Task.Run(() => Save(record));
        }

        static void Save(int record)
        {
            Properties.Settings.Default.record = record;
            Properties.Settings.Default.Save();
        }
    }
}
