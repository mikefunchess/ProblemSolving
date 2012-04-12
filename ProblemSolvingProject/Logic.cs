using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public enum BoardPiece { Invalid, Green, Red, Open };

    class Logic
    {
        BoardPiece[,] GameBoard = new BoardPiece[,] 
        {
            { BoardPiece.Invalid, BoardPiece.Open, BoardPiece.Green, BoardPiece.Green, BoardPiece.Green, BoardPiece.Green, BoardPiece.Green, BoardPiece.Green, BoardPiece.Green, BoardPiece.Invalid },
            { BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Red, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Red, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Red, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Red, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Red, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Red, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Red, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open },
            { BoardPiece.Invalid, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Open, BoardPiece.Invalid }
        };

        Player Player { get; set; }
        Computer Computer { get; set; }

        public Logic(Player player, Computer computer)
        {
            this.Player = player;
            this.Computer = computer;
        }

        public bool MakePlayerMove(Move Move) 
        {
            if (this.Player.IsTurn && this.IsValidPlayerMove(Move))
            {
                GamePiece MoveFrom = Move.MoveFrom;
                GamePiece MoveTo = Move.MoveTo;

                GameBoard[MoveFrom.Row, MoveFrom.Col] = BoardPiece.Open;
                GameBoard[MoveTo.Row, MoveTo.Col] = this.Player.BoardPiece;
                
                this.Player.AddMove(Move);

                this.Player.IsTurn = false;
                this.Computer.IsTurn = true;

                return true;
            }

            return false;
        }

        private bool IsValidPlayerMove(Move Move)
        {
            GamePiece MoveFrom = Move.MoveFrom;
            GamePiece MoveTo = Move.MoveTo;
            BoardPiece MoveFromBoardPiece = GameBoard[MoveFrom.Row, MoveFrom.Col - 1];
            BoardPiece MoveToBoardPiece = GameBoard[MoveTo.Row, MoveTo.Col - 1];

            if (MoveFromBoardPiece == this.Player.BoardPiece && MoveToBoardPiece == BoardPiece.Open) 
            {
                if (this.Player.BoardPiece == BoardPiece.Red)
                {
                    if (MoveTo.Col >= MoveFrom.Col && (MoveTo.Row >= 1 && MoveTo.Row <= 8))
                    {
                        if (MoveTo.Col == MoveFrom.Col + 1 && MoveTo.Row == MoveFrom.Row)
                        {
                            return true;
                        }
                        else if (MoveTo.Col == MoveFrom.Col)
                        {
                            if (MoveTo.Row == MoveFrom.Row - 1 || MoveTo.Row == MoveFrom.Row + 1)
                            {
                                return true;
                            }
                        }
                    }
                }
                else 
                {

                    if (MoveTo.Row >= MoveFrom.Row && (MoveTo.Col >= 2 && MoveTo.Col <= 9))
                    {
                        if (MoveTo.Row == MoveFrom.Row + 1 && MoveTo.Col == MoveFrom.Col)
                        {
                            return true;
                        }
                        else if (MoveTo.Row == MoveFrom.Row)
                        {
                            if (MoveTo.Col == MoveFrom.Col - 1 || MoveTo.Col == MoveFrom.Col + 1)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool MakeComputerMove(Move Move)
        {
            if (this.Computer.IsTurn && this.IsValidComputerMove(Move))
            {
                GamePiece MoveFrom = Move.MoveFrom;
                GamePiece MoveTo = Move.MoveTo;

                GameBoard[MoveFrom.Row, MoveFrom.Col] = BoardPiece.Open;
                GameBoard[MoveTo.Row, MoveTo.Col] = this.Computer.BoardPiece;
                
                this.Computer.AddMove(Move);

                this.Computer.IsTurn = false;
                this.Player.IsTurn = true;
                
                return true;
            }

            return false;
        }

        private bool IsValidComputerMove(Move Move)
        {
            GamePiece MoveFrom = Move.MoveFrom;
            GamePiece MoveTo = Move.MoveTo;
            BoardPiece MoveFromBoardPiece = GameBoard[MoveFrom.Row, MoveFrom.Col];
            BoardPiece MoveToBoardPiece = GameBoard[MoveTo.Row, MoveTo.Col];

            if (MoveFromBoardPiece == this.Computer.BoardPiece && MoveToBoardPiece == BoardPiece.Open) 
            {
                if (this.Computer.BoardPiece == BoardPiece.Red)
                {
                    if (MoveTo.Col >= MoveFrom.Col && (MoveTo.Row >= 2 && MoveTo.Row <= 9)) 
                    {
                        return true;
                    }
                }
                else 
                {
                    if (MoveTo.Row >= MoveFrom.Row && (MoveTo.Col >= 2 && MoveTo.Col <= 9)) 
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Move GetNextMove() 
        {
            //

            return null;
        }
    }
}