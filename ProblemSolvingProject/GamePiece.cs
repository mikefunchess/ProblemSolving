using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class GamePiece
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public GamePiece() { }

        public GamePiece(int Row, int Col)
        {
            this.Row = Row;
            this.Col = Col;
        }
    }
}
