using ChessGame.board;

namespace ChessGame.chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
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

            position.DefiningValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;
                position.Column = position.Column - 1;
            }
            position.DefiningValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;
                position.Column = position.Column + 1;
            }
            position.DefiningValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;
                position.Column = position.Column + 1;
            }
            position.DefiningValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;
                position.Column = position.Column - 1;
            }
            return mat;
        }
    }
}
