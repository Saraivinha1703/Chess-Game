namespace ChessGame.board
{
    class Piece
    {
        public Color Color { get; set; }
        public Position Position { get; set; }
        public int MovimentsAmt { get; set; }
        public Board Board { get; set; }


        public Piece()
        {
        }


        public Piece(Color color, Position position, Board board)
        {
            Color = color;
            Position = position;
            Board = board;
            MovimentsAmt = 0;
        }



    }
}
