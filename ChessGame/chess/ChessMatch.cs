using System;
using ChessGame.board;

namespace ChessGame.chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn { get; set; }
        private Color ActualPlayer { get; set; }
        public Screen Screen { get; set; }
        public bool MatchEnd { get; private set; }
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            PutPieceOn();
            MatchEnd = false;
        }

 
        public void ExecuteMoviment(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseAmtMoviments();
            Piece catchPiece = Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);
        }
        
        public void PutPieceOn()
        {
            Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('c', 1).ToPosition());
            Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('c', 2).ToPosition());
            Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('d', 2).ToPosition());
            Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('e', 2).ToPosition());
            Board.AddPiece(new Tower(Color.White, Board), new ChessPosition('e', 1).ToPosition());
            Board.AddPiece(new King(Color.White, Board), new ChessPosition('d', 1).ToPosition());
            Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('c', 8).ToPosition());
            Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('c', 7).ToPosition());
            Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('d', 7).ToPosition());
            Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('e', 7).ToPosition());
            Board.AddPiece(new Tower(Color.Black, Board), new ChessPosition('e', 8).ToPosition());
            Board.AddPiece(new King(Color.Black, Board), new ChessPosition('d', 8).ToPosition());
            Screen.PrintBoard(Board);
        }
   
        
    }
}
