using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180313goal_gomoku
{
    class BlackPieces : Pieces
    {
        public BlackPieces(int x,int y):base(x,y)
        {
            this.Image = Properties.Resources.black;
        }

        public override PiecesType GetPiecesType()
        {
            return PiecesType.BLACK;
        }
    }
}
