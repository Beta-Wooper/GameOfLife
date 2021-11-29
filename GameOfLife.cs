using System;

namespace GameOfLife
{
    public class LifeSimulation
    {
        private int Height;
        private int Width;
        private bool[,] cells;

        /// <summary>
        /// initialises a new Game of Life
        /// </summary>
        /// <param name="Height">Height of the cell field.</param>
        /// <param name="Width">Width of the cell field.</param>

        public LifeSimulation(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
            cells = new bool[Height, Width];
            GenerateField();
        }

        /// <summary>
        /// Advances the game by one generation and prints the current state to console
        /// </summary>

        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        /// Advance the game by one generation according the Conway's ruleset
        /// </summary>

        public void Grow()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            cells[i, j] = false;
                        }
                        if (numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            cells[i, j] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks how many alive numbers are in the vicinity of a cell.
        /// </summary>
        /// <param name="x">X-Coord of the cell</param>
        /// <param name="y">Y-Coord of the cell</param>
        /// <returns>The number of alive neighbors</returns> 

        private int GetNeighbors(int x, int y)
        {
            int numOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Height || j >= Width)))
                    {
                        if (cells[i, j] == true) numOfAliveNeighbors++;
                    }
                }
            }
            return numOfAliveNeighbors;
        }

        /// <summary>
        /// Draws the game to console
        /// </summary>

        private void DrawGame()
        {
            string buffer = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    buffer += cells[i, j] ? "x" : " ";
                }

                buffer += "\n";
            }
            Console.SetCursorPosition(0, Console.WindowTop);
            Console.Write(buffer.TrimEnd('\n'));
        }

        /// <summary>
        /// Initialises the field with random boolean values
        /// </summary>

        private void GenerateField()
        {
            Random generator = new Random();
            int number;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }
    }

    internal class Program
    {
        // Constants for the game rules
        private const int Height = 5;
        private const int Width = 30;
        private const int MaxRuns = 2;

        private static void Main(string[] args)
        {
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Height, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                //Give the user a chance to view the game in a more reasonable speed
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}