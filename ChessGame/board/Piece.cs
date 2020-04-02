namespace ChessGame.board
{
    class Piece
    {
        public Color Color { get; protected set; }
        public Position Position { get; set; }
        public int MovimentsAmt { get; protected set; }
        public Board Board { get; protected set; }


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
