using System;
using System.Collections.Generic;
using ChessGame.chess;

namespace ChessGame.board
{
    class Screen
    {

        public Screen()
        {
        }

        public static void PrintMatch(ChessMatch cm)
        {
            PrintBoard(cm.Board);
            Console.WriteLine();
            PrintCapturedPieces(cm);
            Console.WriteLine();
            if (!cm.MatchEnd)
            {
                Console.WriteLine("Turn: " + cm.Turn);
                Console.WriteLine("Aguardando jogada: " + cm.ActualPlayer);
            }
            else
            {
                Console.WriteLine("CHECKMATE");
                Console.WriteLine("Winner: " + cm.ActualPlayer);
                Console.ReadLine();
            }
            if (cm.Check)
            {
                Console.WriteLine("CHECK");
            }
        }

        public static void PrintCapturedPieces(ChessMatch cm)
        {

            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintGroup(cm.PiecesCaptured(Color.White));
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Black: ");
            PrintGroup(cm.PiecesCaptured(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void PrintGroup(HashSet<Piece> p)
        {
            
            Console.Write("[");
            foreach(Piece piece in p)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");



        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    PrintPiece(board.Piece[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] pp)
        {
            ConsoleColor OriginalBG = Console.BackgroundColor;
            ConsoleColor BG = ConsoleColor.DarkCyan;

            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    if(pp[i, j] == true)
                    {
                        Console.BackgroundColor = BG;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBG;
                    }
                    
                    PrintPiece(board.Piece[i, j]);
                    Console.BackgroundColor = OriginalBG;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = OriginalBG;
        }

        public static ChessPosition ReceivingPosition(ChessMatch cm)
        {
            
            string s = Console.ReadLine();
            
            char line = s[0];
            int column = int.Parse(s[1] + "");
            if(cm.Board.Column < column)
            {
                throw new BoardException("This position does not exist");
            }
            if(line != 'a' && line != 'b' && line != 'c' && line != 'd' && line != 'e' && line != 'f' && line != 'g' && line != 'h')
            {
                throw new BoardException("This position does not exist");
            }
            return new ChessPosition(line, column);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
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
                Console.Write(" ");
            }
        }

    }
}
