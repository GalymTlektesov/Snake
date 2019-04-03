using System;
using System.Collections.Generic;


namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            Console.ForegroundColor = ConsoleColor.Red;
            // Отрисовка рамочки
            HorizontalLine upline = new HorizontalLine(1, 78, 1, '+');
            upline.Drow();
            HorizontalLine downline = new HorizontalLine(1, 78, 23, '+');
            downline.Drow();

            VerticalLine leftline = new VerticalLine(1, 23, 1, '+');
            leftline.Drow();
            VerticalLine rightline = new VerticalLine(1, 23, 78, '+');
            rightline.Drow();

            wallList.Add(upline);
            wallList.Add(downline);
            wallList.Add(leftline);
            wallList.Add(rightline);
        }


        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Draw();
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Drow();
            }
        }

    }
}
