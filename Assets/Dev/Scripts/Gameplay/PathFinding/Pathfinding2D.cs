using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.PathFinding
{
    public class Pathfinding2D : MonoBehaviour
    {
        private Grid2D grid;
        private Node2D seekerNode;
        private Node2D targetNode;

        public void Initialize(Grid2D grid)
        {
            this.grid = grid;
        }

        public void FindPath(Vector3 startPos, Vector3 targetPos)
        {
            //get player and target position in grid coords
            seekerNode = grid.NodeFromWorldPoint(startPos);
            targetNode = grid.NodeFromWorldPoint(targetPos);

            List<Node2D> openSet = new List<Node2D>();
            HashSet<Node2D> closedSet = new HashSet<Node2D>();
            openSet.Add(seekerNode);

            //calculates path for pathfinding
            while (openSet.Count > 0)
            {

                //iterates through openSet and finds lowest FCost
                Node2D node = openSet[0];
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].FCost <= node.FCost)
                    {
                        if (openSet[i].HCost < node.HCost)
                            node = openSet[i];
                    }
                }

                openSet.Remove(node);
                closedSet.Add(node);

                //If target found, retrace path
                if (node == targetNode)
                {
                    RetracePath(seekerNode, targetNode);
                    return;
                }

                //adds neighbor nodes to openSet
                foreach (Node2D neighbour in grid.GetNeighbors(node))
                {
                    if (neighbour.IsObstacle || closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    int newCostToNeighbour = node.GCost + GetDistance(node, neighbour);
                    if (newCostToNeighbour < neighbour.GCost || !openSet.Contains(neighbour))
                    {
                        neighbour.GCost = newCostToNeighbour;
                        neighbour.HCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = node;

                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour);
                    }
                }
            }
        }

        //reverses calculated path so first node is closest to seeker
        private void RetracePath(Node2D startNode, Node2D endNode)
        {
            List<Node2D> path = new List<Node2D>();
            Node2D currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Reverse();

            grid.Path = path;
        }

        //gets distance between 2 nodes for calculating cost
        private int GetDistance(Node2D nodeA, Node2D nodeB)
        {
            int dstX = Mathf.Abs(nodeA.GridX - nodeB.GridX);
            int dstY = Mathf.Abs(nodeA.GridY - nodeB.GridY);

            if (dstX > dstY)
                return 14 * dstY + 10 * (dstX - dstY);
            return 14 * dstX + 10 * (dstY - dstX);
        }

        public List<Node2D> GetFindedPath()
        {
            return grid.Path;
        }
    }
}
