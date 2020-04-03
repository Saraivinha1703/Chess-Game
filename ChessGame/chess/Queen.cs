using System;
using ChessGame.board;

namespace ChessGame.chess
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {
        }


        public override string ToString()
        {
            return "Q";
        }

    }
}
