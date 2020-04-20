namespace LeetCode30DayChallenge.Questions
{
    using System;
    using System.Collections.Generic;
    public class NumberOfIsland
    {
        public int NumIslands(char[][] grid)
        {

            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            // BFS to traverse the graph and find the islands
            int rows = grid.Length;
            int cols = grid[0].Length;


            //created visited array
            bool[,] visited = new bool[rows, cols];

            //create set that will store islands
            //pair will store each coordinate in island
            //all of pairs constructing island will be stored in List
            List<List<Tuple<int, int>>> islands = new List<List<Tuple<int, int>>>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //check if current coordinates can be start of undiscovered island
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        List<Tuple<int, int>> island = new List<Tuple<int, int>>();
                        findIsland(grid, i, j, visited, island);

                        //add the found island
                        islands.Add(island);
                    }
                }
            }

            return islands.Count;

        }

        private static void findIsland(char[][] grid, int row, int col, bool[,] visited, List<Tuple<int, int>> island)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            if (row < 0 || col < 0 || row >= rows || col >= cols || visited[row, col] || grid[row][col] == '0')
                return;

            //add island coordinates in list
            island.Add(new Tuple<int, int>(row, col));

            //mark the cell visited
            visited[row, col] = true;
            findIsland(grid, row + 1, col, visited, island); // go right
            findIsland(grid, row - 1, col, visited, island); //go left
            findIsland(grid, row, col + 1, visited, island); //go down
            findIsland(grid, row, col - 1, visited, island); // go up
        }
    }
}