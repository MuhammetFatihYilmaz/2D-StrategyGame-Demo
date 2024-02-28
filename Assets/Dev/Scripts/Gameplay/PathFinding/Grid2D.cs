using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace StrategyGame.Gameplay.PathFinding
{
    public class Grid2D : MonoBehaviour
    {
        private Vector3 gridWorldSize = Vector3.zero;
        [SerializeField] private float nodeRadius;
        [SerializeField] private Tilemap obstacleTileMap;
        [SerializeField] private Tilemap groundTileMap;

        public Node2D[,] Grid { get; private set; }
        public int GridSizeX { get; private set; }
        public int GridSizeY { get; private set; }
        public List<Node2D> Path { get => path; set => path = value; }

        private List<Node2D> path = new();
        private Vector3 worldBottomLeft;
        private float nodeDiameter;


        void Awake()
        {
            groundTileMap.CompressBounds();
            gridWorldSize.x = groundTileMap.size.x * 0.75f;
            gridWorldSize.y = groundTileMap.size.y * 0.75f;
            nodeDiameter = nodeRadius * 2;
            GridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
            GridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
            CreateGrid();
        }

        private void CreateGrid()
        {
            Grid = new Node2D[GridSizeX, GridSizeY];
            worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;

            for (int x = 0; x < GridSizeX; x++)
            {
                for (int y = 0; y < GridSizeY; y++)
                {
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                    Grid[x, y] = new Node2D(false, worldPoint, x, y);

                    if (obstacleTileMap.HasTile(obstacleTileMap.WorldToCell(Grid[x, y].WorldPosition)))
                        Grid[x, y].SetObstacleStatus(true);
                    else
                        Grid[x, y].SetObstacleStatus(false);


                }
            }
        }


        //gets the neighboring nodes in the 4 cardinal directions. If you would like to enable diagonal pathfinding, uncomment out that portion of code
        public List<Node2D> GetNeighbors(Node2D node)
        {
            List<Node2D> neighbors = new List<Node2D>();

            //checks and adds top neighbor
            if (node.GridX >= 0 && node.GridX < GridSizeX && node.GridY + 1 >= 0 && node.GridY + 1 < GridSizeY)
                neighbors.Add(Grid[node.GridX, node.GridY + 1]);

            //checks and adds bottom neighbor
            if (node.GridX >= 0 && node.GridX < GridSizeX && node.GridY - 1 >= 0 && node.GridY - 1 < GridSizeY)
                neighbors.Add(Grid[node.GridX, node.GridY - 1]);

            //checks and adds right neighbor
            if (node.GridX + 1 >= 0 && node.GridX + 1 < GridSizeX && node.GridY >= 0 && node.GridY < GridSizeY)
                neighbors.Add(Grid[node.GridX + 1, node.GridY]);

            //checks and adds left neighbor
            if (node.GridX - 1 >= 0 && node.GridX - 1 < GridSizeX && node.GridY >= 0 && node.GridY < GridSizeY)
                neighbors.Add(Grid[node.GridX - 1, node.GridY]);



            // Diagonal movement

            //checks and adds top right neighbor
            if (node.GridX + 1 >= 0 && node.GridX + 1 < GridSizeX && node.GridY + 1 >= 0 && node.GridY + 1 < GridSizeY)
                neighbors.Add(Grid[node.GridX + 1, node.GridY + 1]);

            //checks and adds bottom right neighbor
            if (node.GridX + 1 >= 0 && node.GridX + 1 < GridSizeX && node.GridY - 1 >= 0 && node.GridY - 1 < GridSizeY)
                neighbors.Add(Grid[node.GridX + 1, node.GridY - 1]);

            //checks and adds top left neighbor
            if (node.GridX - 1 >= 0 && node.GridX - 1 < GridSizeX && node.GridY + 1 >= 0 && node.GridY + 1 < GridSizeY)
                neighbors.Add(Grid[node.GridX - 1, node.GridY + 1]);

            //checks and adds bottom left neighbor
            if (node.GridX - 1 >= 0 && node.GridX - 1 < GridSizeX && node.GridY - 1 >= 0 && node.GridY - 1 < GridSizeY)
                neighbors.Add(Grid[node.GridX - 1, node.GridY - 1]);


            return neighbors;
        }


        public Node2D NodeFromWorldPoint(Vector3 worldPosition)
        {
            int x = Mathf.RoundToInt(worldPosition.x - 1 + (GridSizeX / 2));
            int y = Mathf.RoundToInt(worldPosition.y + (GridSizeY / 2));
            x = Mathf.Clamp(x, 0, Grid[Grid.GetLength(0) - 1, 0].GridX);
            y = Mathf.Clamp(y, 0, Grid[0, Grid.GetLength(1)-1].GridY);
            return Grid[x, y];
        }


#if UNITY_EDITOR
        //Draws visual representation of grid
        private void OnDrawGizmos()
        {
            groundTileMap.CompressBounds();
            gridWorldSize.x = groundTileMap.size.x * 0.75f;
            gridWorldSize.y = groundTileMap.size.y * 0.75f;
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));

            if (Grid != null)
            {
                foreach (Node2D n in Grid)
                {
                    if (n.IsObstacle)
                        Gizmos.color = Color.red;
                    else
                        Gizmos.color = Color.white;

                    if (Path != null && Path.Contains(n))
                        Gizmos.color = Color.black;
                    Gizmos.DrawCube(n.WorldPosition, Vector3.one * (nodeRadius));

                }
            }
        }
#endif
    }
}
