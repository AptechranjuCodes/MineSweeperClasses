
using System;

namespace MineSweeperClasses
{
    public class Board
    {
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public int RewordsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum GameStatus { InProgreass, Won, Lost }

        Random random = new Random();

        public Board(int size, float difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Cells[i, j] = new Cell();

            SetupBombs();
            CalculateNumberOfBombNeighbors();
        }

        private void SetupBombs()
        {
            int totalBombs = (int)(Size * Size * Difficulty);
            int count = 0;
            while (count < totalBombs)
            {
                int row = random.Next(Size);
                int col = random.Next(Size);

                if (!Cells[row, col].HasBomb)
                {
                    Cells[row, col].HasBomb = true;
                    count++;
                }
            }
        }

        private void CalculateNumberOfBombNeighbors()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Cells[i, j].BombNeighbors = GetNumberOfBombNeighbors(i, j);
        }

        private int GetNumberOfBombNeighbors(int row, int col)
        {
            int count = 0;
            for (int i = row - 1; i <= row + 1; i++)
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (IsCellInBoard(i, j) && Cells[i, j].HasBomb && !(i == row && j == col))
                        count++;
                }
            return count;
        }

        private bool IsCellInBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        
        public void PrintAnswers()
        {
            // Column headers
            Console.Write("   ");
            for (int col = 0; col < Size; col++)
                Console.Write($"{col,3}");
            Console.WriteLine();

            // Top border
            Console.Write("   ");
            for (int col = 0; col < Size; col++)
                Console.Write("+---");
            Console.WriteLine("+");

            for (int row = 0; row < Size; row++)
            {
                Console.Write($"{row,2} ");
                for (int col = 0; col < Size; col++)
                {
                    string display;
                    if (Cells[row, col].HasBomb)
                        display = "B";
                    else if (Cells[row, col].BombNeighbors == 0)
                        display = ".";
                    else
                        display = Cells[row, col].BombNeighbors.ToString();

                    // Set color
                    if (Cells[row, col].HasBomb)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write($"| {display}");
                    Console.ResetColor();
                }
                Console.WriteLine("|");

                // Border after row
                Console.Write("   ");
                for (int col = 0; col < Size; col++)
                    Console.Write("+---");
                Console.WriteLine("+");
            }
        }

    }
}
