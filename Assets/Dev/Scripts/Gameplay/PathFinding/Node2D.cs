using UnityEngine;

namespace StrategyGame.Gameplay.PathFinding
{
    public class Node2D
    {
        private int gCost;
        private int hCost;
        public int GCost { get => gCost; set => gCost = value; }
        public int HCost { get => hCost; set => hCost = value; }
        public bool IsObstacle { get; private set; }
        public Vector3 WorldPosition { get; private set;}

        public int GridX { get; private set; }
        public int GridY { get; private set; }
        public Node2D parent;


        public Node2D(bool _obstacle, Vector3 _worldPos, int _gridX, int _gridY)
        {
            IsObstacle = _obstacle;
            WorldPosition = _worldPos;
            GridX = _gridX;
            GridY = _gridY;
        }

        public int FCost
        {
            get
            {
                return GCost + HCost;
            }

        }

        public void SetObstacleStatus(bool isOb)
        {
            IsObstacle = isOb;
        }
    }
}
