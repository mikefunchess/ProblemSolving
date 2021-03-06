﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Player
    {
        public bool IsTurn { get; set; }
        public BoardPiece BoardPiece { get; set; }
        public LinkedList<Move> Moves { get; set; }

        public Player() 
        {
            this.Moves = new LinkedList<Move>();
        }

        public Player(bool IsTurn, BoardPiece BoardPiece)
        {
            this.IsTurn = IsTurn;
            this.BoardPiece = BoardPiece;
            this.Moves = new LinkedList<Move>();
        }

        public void AddMove(Move Move) 
        {
            this.Moves.AddLast(Move);
        }
    }
}
