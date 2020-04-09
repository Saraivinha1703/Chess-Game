using System;
using ChessGame.board;

namespace ChessGame.chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board)
        {
        }


        public override string ToString()
        {
            return "H";
        }


        private bool CanMove(Position position)
        {
            Piece p = Board.piece(position);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position position = new Position(0, 0);
            position.DefiningValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            position.DefiningValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            position.DefiningValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            position.DefiningValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            position.DefiningValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            position.DefiningValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            position.DefiningValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            position.DefiningValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            return mat;
        }




    }
}
