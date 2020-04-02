namespace ChessGame.board
{
    class Board
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public Piece[,] Piece { get; set; }

        public Board()
        {
        }

        public Board(int line, int column)
        {
            Line = line;
            Column = column;
            Piece = new Piece[line, column];
        }
    }
}
