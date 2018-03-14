using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180313goal_gomoku
{
    class Game
    {
        
        private PiecesType currentPlayer = PiecesType.BLACK;
        private Board board = new Board();
        private PiecesType winner = PiecesType.NONE;
        public PiecesType Winner { get { return winner; } } 
        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }
        public Pieces PlacePieces(int x, int y)
        {
            Pieces pieces = board.PlacePieces(x, y, currentPlayer);
            if (pieces != null)
            {
                CheckWinner();

                if (currentPlayer == PiecesType.BLACK)
                {
                    currentPlayer = PiecesType.WHITE;
                }
                else if (currentPlayer == PiecesType.WHITE)
                {
                    currentPlayer = PiecesType.BLACK;
                }
                return pieces;
            }
            return null;
        }
        public int CheckCount(int x,int y, int xDir ,int yDir) {
            int count = 1 ;
            while (count < 5)
            {
                int targetX = x + count * xDir;
                int targetY = y + count * yDir;
                if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                     targetY < 0 || targetY >= Board.NODE_COUNT ||
                     board.GetPiecesType(targetX, targetY) != currentPlayer)
                    break;
                count++;
            }
            return count;
        }
        private void CheckWinner() {
            int centerX = board.LastPlaseNode.X;
            int centerY = board.LastPlaseNode.Y;
            int[] num = new int[8];
            int i = 0;
            for (int xDir = -1; xDir <= 1; xDir++)
                for (int yDir = -1; yDir <= 1; yDir++) {
                    if (xDir == 0 && yDir == 0) continue;
                    num[i]=CheckCount(centerX,centerY,xDir,yDir);
                    i++;    
                }

            if ((num[0]+num[7])>5|| (num[1] + num[6])> 5|| (num[2] + num[5])> 5|| (num[3] + num[4])> 5)
            {
                winner = currentPlayer;
                //winner = board.GetPiecesType(board.LastPlaseNode.X, board.LastPlaseNode.Y);         
            }

        }
    }
}
