using System;
using ChessGame.board;
using ChessGame.chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch cm = new ChessMatch();
                while (!cm.MatchEnd)
                {
                    Console.Clear();
                    Screen.PrintBoard(cm.Board);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReceivingPosition().ToPosition();
                    Console.WriteLine("Destiny: ");
                    Position destiny = Screen.ReceivingPosition().ToPosition();
                    cm.ExecuteMoviment(origin, destiny);

                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}
