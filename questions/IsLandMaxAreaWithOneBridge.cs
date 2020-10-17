namespace Faang
{
    using System;
    using System.Collections.Generic;

    public class IslandConnectedOneBridge
    {
        internal (int, int)[] direction = new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        Dictionary<(int, int), int> connectedComponents = new Dictionary<(int, int), int>();

        public int MaxIslandAfterBridge(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            
            int rows = grid.Length;
            int cols = grid[0].Length;
            int componentId = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    List<(int, int)> connectedIndices = new List<(int, int)>();
                    if (grid[i][j] == 1)
                    {
                        DFS(grid, i, j, connectedIndices);
                        updateConnectedIndices(grid, connectedIndices, componentId);
                        componentId++;
                    }
                }
            }

            int maxArea = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        maxArea = Math.Max(maxArea, GetMaxConnectedArea(grid, rows, cols, i, j));
                    }
                }
            }

            return maxArea;
        }

        private int GetMaxConnectedArea(int[][] grid, int rows, int cols, int i, int j)
        {
            int currArea = 1; // for current cell
            HashSet<int> componentSet = new HashSet<int>();
            for (int m = 0; m < 4; m++)
            {
                (int x, int y) = direction[i];
                int row = i + x;
                int col = j + y;
                if (isInValid(rows, cols, row, col))
                    continue;

                // set Add method will return false if the element is already
                // present, so it will not add common components more than once.
                if (grid[row][col] != 0 &&
                    connectedComponents.ContainsKey((row, col))
                    && componentSet.Add(connectedComponents[(row, col)]))
                {
                    currArea += grid[row][col];
                }
            }
            return currArea;
        }

        private bool isInValid(int rows, int cols, int x, int y)
        {
            return x < 0 || x >= rows || y < 0 || y >= cols;
        }

        private void updateConnectedIndices(int[][] grid, List<(int, int)> connectedIndices, int componentId)
        {
            int count = connectedIndices.Count;

            foreach ((int x, int y) in connectedIndices)
            {
                connectedComponents.Add((x, y), componentId);
                grid[x][y] = count;
            }
        }

        private void DFS(int[][] grid, int x, int y, List<(int, int)> connectedIndices)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || grid[x][y] != 1)
                return;

            grid[x][y] = 2;
            connectedIndices.Add((x, y));
            DFS(grid, x + 1, y, connectedIndices);
            DFS(grid, x - 1, y, connectedIndices);
            DFS(grid, x, y + 1, connectedIndices);
            DFS(grid, x, y - 1, connectedIndices);
        }
    }
}
