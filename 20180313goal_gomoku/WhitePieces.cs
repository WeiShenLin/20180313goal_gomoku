using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180313goal_gomoku
{
    class WhitePieces : Pieces
    {
        public WhitePieces(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }
        public override PiecesType GetPiecesType()
        {
            return PiecesType.WHITE;
        }
    }
}

