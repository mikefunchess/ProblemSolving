using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public enum BoardPiece { Invalid, Green, Red, Open };

    class Logic
    {
        GamePiece[] computerGamePieces;
        GamePiece[] playerGamePieces;

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

            if (this.Computer.BoardPiece == BoardPiece.Green)
            {
                this.computerGamePieces = new GamePiece[]
                {
                    new GamePiece(0, 2),
                    new GamePiece(0, 3),
                    new GamePiece(0, 4),
                    new GamePiece(0, 5),
                    new GamePiece(0, 6),
                    new GamePiece(0, 7),
                    new GamePiece(0, 8)
                };

                this.playerGamePieces = new GamePiece[]
                {
                    new GamePiece(2, 0),
                    new GamePiece(3, 0),
                    new GamePiece(4, 0),
                    new GamePiece(5, 0),
                    new GamePiece(6, 0),
                    new GamePiece(7, 0),
                    new GamePiece(8, 0)
                };
            }
            else
            {
                this.computerGamePieces = new GamePiece[]
                {
                    new GamePiece(2, 0),
                    new GamePiece(3, 0),
                    new GamePiece(4, 0),
                    new GamePiece(5, 0),
                    new GamePiece(6, 0),
                    new GamePiece(7, 0),
                    new GamePiece(8, 0)
                };

                this.playerGamePieces = new GamePiece[]
                {
                    new GamePiece(0, 2),
                    new GamePiece(0, 3),
                    new GamePiece(0, 4),
                    new GamePiece(0, 5),
                    new GamePiece(0, 6),
                    new GamePiece(0, 7),
                    new GamePiece(0, 8)
                };
            }
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

            if (MoveFrom.Row < GameBoard.GetLength(0) && MoveTo.Row < GameBoard.GetLength(0) && MoveFrom.Col < GameBoard.GetLength(1) && MoveTo.Col < GameBoard.GetLength(1))
            {
                BoardPiece MoveFromBoardPiece = GameBoard[MoveFrom.Row, MoveFrom.Col];
                BoardPiece MoveToBoardPiece = GameBoard[MoveTo.Row, MoveTo.Col];

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

                        if (MoveTo.Row >= MoveFrom.Row && (MoveTo.Col >= 1 && MoveTo.Col <= 8))
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

            if (MoveFrom.Row < GameBoard.GetLength(0) && MoveTo.Row < GameBoard.GetLength(0) && MoveFrom.Col < GameBoard.GetLength(1) && MoveTo.Col < GameBoard.GetLength(1))
            {
                BoardPiece MoveFromBoardPiece = GameBoard[MoveFrom.Row, MoveFrom.Col];
                BoardPiece MoveToBoardPiece = GameBoard[MoveTo.Row, MoveTo.Col];

                if (MoveFromBoardPiece == this.Computer.BoardPiece && MoveToBoardPiece == BoardPiece.Open)
                {
                    if (this.Computer.BoardPiece == BoardPiece.Red)
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

                        if (MoveTo.Row >= MoveFrom.Row && (MoveTo.Col >= 1 && MoveTo.Col <= 8))
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
            }

            return false;
        }

        public Move GetNextMove(bool asComputer) 
        {
            Move bestMove = null;
            int evaluation = 0;
            int pos = 0;

            for (int i = 0; i < computerGamePieces.Length; i++) 
            {
                GamePiece computerGamePiece = computerGamePieces[i];

                if (Computer.BoardPiece == BoardPiece.Green)
                {
                    if (computerGamePiece.Row < 9)
                    {
                        Move moveDown = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row + 1, computerGamePiece.Col));

                        if (IsValidComputerMove(moveDown))
                        {
                            int tempEval = Eval(GameBoard, moveDown);

                            if (tempEval >= evaluation)
                            {
                                bestMove = moveDown;
                                evaluation = tempEval;
                                pos = i;
                            }
                        }

                        Move moveLeft = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row, computerGamePiece.Col - 1));

                        if (IsValidComputerMove(moveLeft))
                        {
                            int tempEval = Eval(GameBoard, moveLeft);

                            if (tempEval >= evaluation)
                            {
                                bestMove = moveLeft;
                                evaluation = tempEval;
                                pos = i;
                            }
                        }

                        Move moveRight = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row, computerGamePiece.Col + 1));

                        if (IsValidComputerMove(moveRight))
                        {
                            int tempEval = Eval(GameBoard, moveRight);

                            if (tempEval >= evaluation)
                            {
                                bestMove = moveRight;
                                evaluation = tempEval;
                                pos = i;
                            }
                        }
                    }
                }
                else
                {
                    if (computerGamePiece.Col < 9)
                    {
                        Move moveRight = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row, computerGamePiece.Col + 1));

                        if (IsValidComputerMove(moveRight))
                        {
                            int tempEval = Eval(GameBoard, moveRight);

                            if (tempEval >= evaluation)
                            {
                                bestMove = moveRight;
                                evaluation = tempEval;
                                pos = i;
                            }
                        }

                        Move moveUp = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row - 1, computerGamePiece.Col));

                        if (IsValidComputerMove(moveUp))
                        {
                            int tempEval = Eval(GameBoard, moveUp);

                            if (tempEval >= evaluation)
                            {
                                bestMove = moveUp;
                                evaluation = tempEval;
                                pos = i;
                            }
                        }

                        Move moveDown = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row + 1, computerGamePiece.Col));

                        if (IsValidComputerMove(moveDown))
                        {
                            int tempEval = Eval(GameBoard, moveDown);

                            if (tempEval >= evaluation)
                            {
                                bestMove = moveDown;
                                evaluation = tempEval;
                                pos = i;
                            }
                        }
                    }
                }
            }

            if (bestMove == null)
            {
                for (int i = 0; i < computerGamePieces.Length; i++)
                {
                    GamePiece computerGamePiece = computerGamePieces[i];

                    if (Computer.BoardPiece == BoardPiece.Green)
                    {
                        if (computerGamePiece.Row == 9)
                        {
                            Move moveLeft = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row, computerGamePiece.Col - 1));

                            if (IsValidComputerMove(moveLeft))
                            {
                                int tempEval = Eval(GameBoard, moveLeft);

                                if (tempEval >= evaluation)
                                {
                                    bestMove = moveLeft;
                                    evaluation = tempEval;
                                    pos = i;
                                }
                            }

                            Move moveRight = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row, computerGamePiece.Col + 1));

                            if (IsValidComputerMove(moveRight))
                            {
                                int tempEval = Eval(GameBoard, moveRight);

                                if (tempEval >= evaluation)
                                {
                                    bestMove = moveRight;
                                    evaluation = tempEval;
                                    pos = i;
                                }
                            }
                        }   
                    }
                    else
                    {
                        if (computerGamePiece.Col == 9)
                        {
                            Move moveUp = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row - 1, computerGamePiece.Col));

                            if (IsValidComputerMove(moveUp))
                            {
                                int tempEval = Eval(GameBoard, moveUp);

                                if (tempEval >= evaluation)
                                {
                                    bestMove = moveUp;
                                    evaluation = tempEval;
                                    pos = i;
                                }
                            }

                            Move moveDown = new Move(computerGamePiece, new GamePiece(computerGamePiece.Row + 1, computerGamePiece.Col));

                            if (IsValidComputerMove(moveDown))
                            {
                                int tempEval = Eval(GameBoard, moveDown);

                                if (tempEval >= evaluation)
                                {
                                    bestMove = moveDown;
                                    evaluation = tempEval;
                                    pos = i;
                                }
                            }
                        }
                    }
                }
            }

            if (Computer.BoardPiece == BoardPiece.Green)
            {
                computerGamePieces[pos] = bestMove.MoveTo;
            }
            else
            {
                computerGamePieces[pos] = bestMove.MoveTo;
            }

            return bestMove;
        }

        private int Eval(BoardPiece[,] gameBoard, Move move)
        {
            int totalPoints = 0;
            GamePiece from = move.MoveFrom;
            GamePiece to = move.MoveTo;
            BoardPiece MoveFromBoardPiece = GameBoard[from.Row, from.Col];

            if (MoveFromBoardPiece == BoardPiece.Green)
            {
                // Forward
                totalPoints += 2 * (to.Row - from.Row) + to.Row % GameBoard.GetLength(0);

                // Sideways
                if (from.Col < to.Col && from.Col != to.Col) 
                {
                    if (to.Row < 9 && GameBoard[to.Row + 1, to.Col] == BoardPiece.Open)
                    {
                        totalPoints += 1 * (to.Col - from.Col);
                    }
                }
                else if (from.Col != to.Col)
                {
                    if (to.Row < 9 && GameBoard[to.Row + 1, to.Col] == BoardPiece.Open)
                    {
                        totalPoints += 1 * (from.Col - to.Col);
                    }
                }

                // Moving out of a blocking position
                if (GameBoard[from.Row, from.Col - 1] == BoardPiece.Red)
                {
                    totalPoints--;
                }

                // Moving into a blocking position
                if (GameBoard[to.Row, to.Col - 1] == BoardPiece.Red)
                {
                    totalPoints++;
                }
            }
            else
            {
                // Forward
                totalPoints += 2 * (to.Col - from.Col) + to.Col % GameBoard.GetLength(1);

                // Sideways
                if (from.Row < to.Row && from.Row != to.Row)
                {
                    if (to.Col < 9 && GameBoard[to.Row, to.Col + 1] == BoardPiece.Open)
                    {
                        totalPoints += 1 * (to.Row - from.Row);
                    }
                }
                else if (from.Row != to.Row)
                {
                    if (to.Col < 9 && GameBoard[to.Row, to.Col + 1] == BoardPiece.Open)
                    {
                        totalPoints += 1 * (from.Row - to.Row);
                    }
                }

                if (GameBoard[from.Row - 1, from.Col] == BoardPiece.Green)
                {
                    totalPoints--;
                }

                if (GameBoard[to.Row - 1, to.Col] == BoardPiece.Green)
                {
                    totalPoints++;
                }
            }

            return totalPoints;
        }
    }
}