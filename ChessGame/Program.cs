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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(cm);
                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReceivingPosition(cm).ToPosition();
                        cm.ValidatingOrigin(origin);

                        bool[,] PP = cm.Board.piece(origin).PossibleMoviments();

                        Console.Clear();
                        Screen.PrintBoard(cm.Board, PP);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReceivingPosition(cm).ToPosition();
                        cm.ValidatingDestiny(origin, destiny);
                        cm.PerformMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }
                Console.Clear();
                Screen.PrintMatch(cm);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}
