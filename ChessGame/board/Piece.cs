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


        public Piece(Color color, Board board)
        {
            Color = color;
            Position = null;
            Board = board;
            MovimentsAmt = 0;
        }

        public void IncreaseAmtMoviments()
        {
            MovimentsAmt++;
        }

    }
}
