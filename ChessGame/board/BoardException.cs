using System;
namespace ChessGame.board
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
    }
}
