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
        private void CheckWinner() {
            int centerX = board.LastPlaseNode.X;
            int centerY = board.LastPlaseNode.Y;
            int count = 1;
            int num = 1;

            for (int xDir = -1; xDir <= 0; xDir++)
                for (int yDir = -1; yDir <= 1; yDir++) {
                    if (xDir == 0 && (yDir == 0||yDir == 1)) continue;
                    
                    bool EndR = false;
                    bool EndL = false;
                    while (count < 5)
                    {
                        int targetXR = centerX + count * xDir;
                        int targetYR = centerY + count * yDir;
                        int targetXL = centerX - count * xDir;
                        int targetYL = centerY - count * yDir;
                        if ((targetXR < 0 || targetXR >= Board.NODE_COUNT ||
                             targetYR < 0 || targetYR >= Board.NODE_COUNT ||
                             board.GetPiecesType(targetXR, targetYR) != currentPlayer) &&
                             (targetXL < 0 || targetXL >= Board.NODE_COUNT ||
                             targetYL < 0 || targetYL >= Board.NODE_COUNT ||
                             board.GetPiecesType(targetXL, targetYL) != currentPlayer))
                            break;

                        if (!(targetXR < 0 || targetXR >= Board.NODE_COUNT ||
                             targetYR < 0 || targetYR >= Board.NODE_COUNT ||
                             board.GetPiecesType(targetXR, targetYR) != currentPlayer))
                        {
                            if (EndR == false) num++;
                        }
                        else {
                            EndR = true;
                        }

                        if (!(targetXL < 0 || targetXL >= Board.NODE_COUNT ||
                             targetYL < 0 || targetYL >= Board.NODE_COUNT ||
                             board.GetPiecesType(targetXL, targetYL) != currentPlayer))
                        {
                            if (EndL == false) num++;
                        }
                        else {
                            EndL = true;
                        }
                            
                        count++;
                        
                    }
                    if (num == 5)
                    {
                        winner = currentPlayer;
                        //winner = board.GetPiecesType(board.LastPlaseNode.X, board.LastPlaseNode.Y);         
                    }
                }

                
        }
    }
}
