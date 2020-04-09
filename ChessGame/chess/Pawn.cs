using ChessGame.board;

namespace ChessGame.chess
{
    class Pawn : Piece
    {
        private ChessMatch CM;
        public Pawn(Color color, Board board, ChessMatch cm) : base(color, board)
        {
            CM = cm;
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

                if(Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.piece(left) == CM.VulnerableEnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistEnemy(right) && Board.piece(right) == CM.VulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
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
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.piece(left) == CM.VulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistEnemy(right) && Board.piece(right) == CM.VulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }

            }
            return mat;
        }

    }
}
