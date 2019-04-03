using System;


namespace Snake
{
    class FoodCreator
    {
        int mapWidht;
        int mapHight;
        char sym;

        Random rnd = new Random();

        public FoodCreator(int mapWidnt, int mapHight, char sym)
        {
            this.mapHight = mapHight;
            this.mapWidht = mapWidnt;
            this.sym = sym;

        }


        public Point CreateFood()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int x = rnd.Next(2, mapWidht - 2);
            int y = rnd.Next(2, mapHight - 2);
            return new Point(x, y, sym);
        }
    }
}
