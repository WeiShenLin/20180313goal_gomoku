using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _20180313goal_gomoku
{
    class Board
    {
        public static readonly int NODE_COUNT = 9;
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTRANCE = 75;
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        private Pieces[,] pieces = new Pieces[NODE_COUNT,NODE_COUNT];
        private Point lastPlaceNode = NO_MATCH_NODE;
        public Point LastPlaseNode{
            get { return lastPlaceNode;
            }  
        }

        public PiecesType GetPiecesType(int nodeIdX, int nodeIdY) {
            if(nodeIdX>=NODE_COUNT||nodeIdY>=NODE_COUNT)
                return PiecesType.NONE;
            if (pieces[nodeIdX, nodeIdY] == null)
                return PiecesType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPiecesType();
        }

        public bool CanBePlaced(int x, int y) {
            Point nodeId = findTheClosetNode(x, y);
            if (nodeId == NO_MATCH_NODE)
                return false;
            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return false;
            }
            return true;
        }
        public Pieces PlacePieces(int x, int y, PiecesType type) {
            Point nodeId = findTheClosetNode(x, y);
            if (nodeId == NO_MATCH_NODE)
                return null;

            if (pieces[nodeId.X, nodeId.Y] != null) {
                return null;
            }
            Point formPos = convertToFormPosition(nodeId);
            if (type == PiecesType.BLACK)
            {
                pieces[nodeId.X, nodeId.Y] = new BlackPieces(formPos.X, formPos.Y);
            }
            else if(type == PiecesType.WHITE) {
                pieces[nodeId.X, nodeId.Y] = new WhitePieces(formPos.X, formPos.Y);
            }
            lastPlaceNode = nodeId;
            return pieces[nodeId.X, nodeId.Y];
        }
        private Point convertToFormPosition(Point nodeId) {
            Point FormPositiom = new Point();
            FormPositiom.X = nodeId.X * NODE_DISTRANCE + OFFSET;
            FormPositiom.Y = nodeId.Y * NODE_DISTRANCE + OFFSET;
            return FormPositiom;
        }

        private Point findTheClosetNode(int x, int y) {
            int nodeIdX = findTheClosetNode(x);
            if (nodeIdX == -1) {
                return NO_MATCH_NODE;
            }
            int nodeIdY = findTheClosetNode(y);
            if (nodeIdY == -1)
            {
                return NO_MATCH_NODE;
            }
            return new Point(nodeIdX,nodeIdY);

        }
        private int findTheClosetNode(int pos)
        {
            pos -= OFFSET;
            int quotient = pos / NODE_DISTRANCE;
            int reminder = pos % NODE_DISTRANCE;
            if (quotient >= NODE_COUNT || (quotient + 1) >= NODE_COUNT)
                return -1;
            if (reminder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if (reminder >= NODE_DISTRANCE - NODE_RADIUS)
            {
                return quotient + 1;
            }
            else
                return -1;


        }
    }
}
