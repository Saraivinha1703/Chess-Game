namespace ChessGame.board
{
    abstract class Piece
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

        public void DecreaseAmtMoviments()
        {
            MovimentsAmt--;
        }
        public bool ExistPossibleMoviments()
        {
            bool[,] mat = PossibleMoviments();

            for (int i = 0; i < Board.Line; i++)
            {
                for (int j = 0; j < Board.Column; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool KeepingPosition(Position position)
        {
            return PossibleMoviments()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoviments();
    }
}
