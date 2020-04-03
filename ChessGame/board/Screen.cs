using System;
using ChessGame.chess;

namespace ChessGame.board
{
    class Screen
    {

        public Screen()
        {
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    if (board.Piece[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece[i, j]);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessPosition ReceivingPosition()
        {
            string s = Console.ReadLine();
            char line = s[0];
            int column = int.Parse(s[1] + "");
            return new ChessPosition(line, column);
        }
        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

    }
}
