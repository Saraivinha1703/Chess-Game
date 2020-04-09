using System;
using ChessGame.board;

namespace ChessGame.chess
{
    class King : Piece
    {
        private ChessMatch ChessMatch; 
        public King(Color color, Board board, ChessMatch cm):base(color, board)
        {
            ChessMatch = cm;
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.piece(position);
            return p == null || p.Color != Color;
        }

        private bool AssayTowerRock(Position position)
        {
            Piece p = Board.piece(position);
            return p != null && p is Tower && p.Color == Color && p.MovimentsAmt == 0;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position position = new Position(0, 0);

            position.DefiningValues(Position.Line - 1, Position.Column);
            
            if(Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            
            position.DefiningValues(Position.Line - 1, Position.Column + 1);
            
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            
            position.DefiningValues(Position.Line, Position.Column + 1);
            
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            
            position.DefiningValues(Position.Line + 1, Position.Column + 1);
            
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            
            position.DefiningValues(Position.Line + 1, Position.Column);
            
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            
            position.DefiningValues(Position.Line + 1, Position.Column - 1);
            
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            
            position.DefiningValues(Position.Line, Position.Column - 1);
            
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }
            
            position.DefiningValues(Position.Line - 1, Position.Column - 1);
            
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            if(MovimentsAmt == 0 && !ChessMatch.Check)
            {
                Position pT1 = new Position(Position.Line, Position.Column + 3);
                if (AssayTowerRock(pT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(Board.piece(p1) == null && Board.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                Position pT2 = new Position(Position.Line, Position.Column - 4);
                if (AssayTowerRock(pT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
