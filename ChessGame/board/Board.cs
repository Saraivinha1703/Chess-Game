using ChessGame.chess;

namespace ChessGame.board
{
    class Board
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public Piece[,] Piece { get; private set; }

        public Board()
        {
        }

        public Board(int line, int column)
        {
            Line = line;
            Column = column;
            Piece = new Piece[line, column];
        }
        public void AddPiece(Piece piece, Position position)
        {
            if (ExistPiece(position))
            {
                throw new BoardException("An piece alredy exist in this position!");
            }
            Piece[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (piece(position) == null)
            {
                return null;
            }
            Piece aux = piece(position);
            aux.Position = null;
            Piece[position.Line, position.Column] = null;
            return aux;
        }
        public bool ExistPiece(Position position)
        {
            ValidatePosition(position);
            return piece(position) != null;
        }

        public Piece piece(int line, int column)
        {
            return Piece[line, column];
        }

        public Piece piece(Position position)
        {
            return Piece[position.Line, position.Column];
        }

        public bool ValidPosition(Position position)
        {
            if(position.Line < 0 || position.Line >= Line || position.Column < 0 || position.Column >= Column)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position");
            }
        }
    }
}
