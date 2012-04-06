using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Move
    {
        public GamePiece MoveFrom { get; set; }
        public GamePiece MoveTo { get; set; }

        public Move(GamePiece MoveFrom, GamePiece MoveTo)
        {
            this.MoveFrom = MoveFrom;
            this.MoveTo = MoveTo;
        }
    }
}
