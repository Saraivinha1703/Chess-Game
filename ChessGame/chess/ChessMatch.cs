using System;
using System.Collections.Generic;
using ChessGame.board;

namespace ChessGame.chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public Screen Screen { get; set; }
        public bool MatchEnd { get; private set; }
        public HashSet<Piece> Pieces { get; set; }
        public HashSet<Piece> CapturedPiece { get; set; }
        public bool Check { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            CapturedPiece = new HashSet<Piece>();
            PutPieceOn();
            MatchEnd = false;
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Piece cp = ExecuteMoviment(origin, destiny);
            if (IsInCheck(ActualPlayer))
            {
                UndoMoviment(origin, destiny, cp);
                throw new BoardException("You can not be in check");
            }

            Piece p = Board.piece(destiny);
            if(p.Color == Color.White && destiny.Line == 0 || p.Color == Color.Black && destiny.Line == 7)
            {
                p = Board.RemovePiece(destiny);
                Pieces.Remove(p);
                Piece queen = new Queen(p.Color, Board);
                Board.AddPiece(queen, destiny);
                Pieces.Add(queen);
            }

            if (IsInCheck(Opponent(ActualPlayer)))
            {
                Check = true;
            }

            else
            {
                Check = false;
            }

            if (AssayCheckMate(Opponent(ActualPlayer)))
            {
                MatchEnd = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
            if (p is Pawn && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2))
            {
                VulnerableEnPassant = p;
            }
            else
            {
                VulnerableEnPassant = null;
            }
        }


        private void ChangePlayer()
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }
            else
            {
                ActualPlayer = Color.White;
            }
        }

        public bool IsInCheck(Color color)
        {
            Piece k = king(color);
            if (k == null)
            {
                throw new BoardException("Does not exist an " + color + " king in the board");
            }
            foreach (Piece p in PiecesInGame(Opponent(color)))
            {
                bool[,] mat = p.PossibleMoviments();
                if (mat[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool AssayCheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece p in PiecesInGame(color))
            {
                bool[,] mat = p.PossibleMoviments();
                for (int i = 0; i < Board.Line; i++)
                {
                    for (int j = 0; j < Board.Column; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = p.Position;
                            Position destiny = new Position(i, j);
                            Piece cp = ExecuteMoviment(origin, destiny);
                            bool acm = IsInCheck(color);
                            UndoMoviment(origin, destiny, cp);
                            if (!acm)
                            {
                                return false;
                            }
                        }



                    }
                }
            }
            return true;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece p in PiecesInGame(color))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public void ValidatingOrigin(Position origin)
        {
            if (Board.piece(origin) == null)
            {
                throw new BoardException("Does not exist a piece in this position");
            }
            if (ActualPlayer != Board.piece(origin).Color)
            {
                throw new BoardException("You can not choose this piece");
            }
            if (!Board.piece(origin).ExistPossibleMoviments())
            {
                throw new BoardException("This piece can not be move");
            }

        }
        public void ValidatingDestiny(Position origin, Position destiny)
        {
            if (!Board.piece(origin).KeepingPosition(destiny))
            {
                throw new BoardException("You can not move the piece to this position");
            }
        }

        public Piece ExecuteMoviment(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseAmtMoviments();
            Piece catchPiece = Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);
            if (catchPiece != null)
            {
                CapturedPiece.Add(catchPiece);
            }
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position poT = new Position(origin.Line, origin.Column + 3);
                Position pdT = new Position(origin.Line, origin.Column + 1);
                Piece T = Board.RemovePiece(poT);
                T.IncreaseAmtMoviments();
                Board.AddPiece(T, pdT);
            }
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position poT = new Position(origin.Line, origin.Column - 4);
                Position pdT = new Position(origin.Line, origin.Column - 1);
                Piece T = Board.RemovePiece(poT);
                T.IncreaseAmtMoviments();
                Board.AddPiece(T, pdT);
            }
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && catchPiece == null)
                {
                    Position pB;
                    if (p.Color == Color.White)
                    {
                        pB = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else
                    {
                        pB = new Position(destiny.Line - 1, destiny.Column);
                    }
                    catchPiece = Board.RemovePiece(pB);
                    CapturedPiece.Add(catchPiece);
                }
            }
            return catchPiece;
        }

        public void UndoMoviment(Position origin, Position destiny, Piece piece)
        {
            Piece p = Board.RemovePiece(destiny);
            p.DecreaseAmtMoviments();
            if (piece != null)
            {
                Board.AddPiece(piece, destiny);
                CapturedPiece.Remove(piece);
            }
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position poT = new Position(origin.Line, origin.Column + 3);
                Position pdT = new Position(origin.Line, origin.Column + 1);
                Piece T = Board.RemovePiece(pdT);
                T.DecreaseAmtMoviments();
                Board.AddPiece(T, poT);
            }
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position poT = new Position(origin.Line, origin.Column - 4);
                Position pdT = new Position(origin.Line, origin.Column - 1);
                Piece T = Board.RemovePiece(pdT);
                T.DecreaseAmtMoviments();
                Board.AddPiece(T, poT);
            }
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && piece == VulnerableEnPassant)
                {
                    Piece pawn = Board.RemovePiece(destiny);
                    Position pB;
                    if (p.Color == Color.White)
                    {
                        pB = new Position(3, destiny.Column);
                    }
                    else
                    {
                        pB = new Position(4, destiny.Column);
                    }
                    Board.AddPiece(pawn, pB);
                }

            }
            Board.AddPiece(p, origin);
        }

        public HashSet<Piece> PiecesCaptured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in CapturedPiece)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }
        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in Pieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(PiecesCaptured(color));
            return aux;
        }

        public void PutNewPiece(char line, int column, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(line, column).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPieceOn()
        {
            PutNewPiece('e', 1, new King(Color.White, Board, this));
            PutNewPiece('d', 1, new Queen(Color.White, Board));
            PutNewPiece('b', 1, new Horse(Color.White, Board));
            PutNewPiece('c', 1, new Bishop(Color.White, Board));
            PutNewPiece('a', 1, new Tower(Color.White, Board));
            PutNewPiece('h', 1, new Tower(Color.White, Board));
            PutNewPiece('f', 1, new Bishop(Color.White, Board));
            PutNewPiece('g', 1, new Horse(Color.White, Board));
            PutNewPiece('a', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('b', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('c', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('d', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('e', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('f', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('g', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('h', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('e', 8, new King(Color.Black, Board, this));
            PutNewPiece('d', 8, new Queen(Color.Black, Board));
            PutNewPiece('b', 8, new Horse(Color.Black, Board));
            PutNewPiece('c', 8, new Bishop(Color.Black, Board));
            PutNewPiece('a', 8, new Tower(Color.Black, Board));
            PutNewPiece('h', 8, new Tower(Color.Black, Board));
            PutNewPiece('f', 8, new Bishop(Color.Black, Board));
            PutNewPiece('g', 8, new Horse(Color.Black, Board));
            PutNewPiece('a', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('b', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('c', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('d', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('e', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('f', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('g', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('h', 7, new Pawn(Color.Black, Board, this));
        }


    }
}
