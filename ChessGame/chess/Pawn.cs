using ChessGame.board;

namespace ChessGame.chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position position)
        {
            Piece p = Board.piece(position);
            return p != null && p.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.piece(position) == null;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position position = new Position(0, 0);
            if (Color == Color.White)
            {
                position.DefiningValues(Position.Line - 1, Position.Column);

                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Line, position.Column] = true;
                }
                position.DefiningValues(Position.Line - 2, Position.Column);

                if (Board.ValidPosition(position) && Free(position) && MovimentsAmt == 0)
                {
                    mat[position.Line, position.Column] = true;
                }
                position.DefiningValues(Position.Line - 1, Position.Column - 1);

                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }
                position.DefiningValues(Position.Line - 1, Position.Column + 1);

                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.DefiningValues(Position.Line + 1, Position.Column);

                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Line, position.Column] = true;
                }
                position.DefiningValues(Position.Line + 2, Position.Column);

                if (Board.ValidPosition(position) && Free(position) && MovimentsAmt == 0)
                {
                    mat[position.Line, position.Column] = true;
                }
                position.DefiningValues(Position.Line + 1, Position.Column - 1);

                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }
                position.DefiningValues(Position.Line + 1, Position.Column + 1);

                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }

            }
            return mat;
        }

    }
}
