using MineSweeperClasses;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, welcome to Minesweeper");
        Console.WriteLine("Here is the answer key for the first board");
        Board board1 = new Board(10, 0.15f);
        board1.PrintAnswers();

        Console.WriteLine("\nHere is the answer key for the second board");
        Board board2 = new Board(15, 0.15f);
        board2.PrintAnswers();
    }
}
