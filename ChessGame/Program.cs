using System;
using ChessGame.board;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Screen.PrintBoard(board);
        }
    }
}
