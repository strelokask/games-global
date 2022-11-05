namespace GamesGlobal.Services
{
    public class AreaCalculationService : IAreaCalculationService
    {
        private readonly string Land = "#";
        private readonly string Water = "O";
        public int CalculateArea(string[][] grid)
        {
            var isValid = IsValid(grid);

            if (!isValid) throw new ArgumentException("Unexpected character in grid");

            return SurfaceAreaOfWater(grid);
        }

        private int SurfaceAreaOfWater(string[][] grid)
        {
            var area = 0;

            for(int i = 0; i < grid.Length; i++){
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == Water)
                    {
                        area += DFS(grid, i, j);
                    }
                }
            }

            return area;
        }

        private int DFS(string[][] grid, int i, int j)
        {
            var cnt = 0;
            if (i >= grid.Length || j < 0 || i < 0 || j >= grid[i].Length) return cnt;
            if (grid[i][j] == Water)
            {
                grid[i][j] = "VISITED";
                cnt += 1;
                cnt += DFS(grid, i + 1, j);
                cnt += DFS(grid, i - 1, j);
                cnt += DFS(grid, i, j + 1);
                cnt += DFS(grid, i, j - 1);
            }

            return cnt;
        }

        private bool IsValid(string[][] grid)
        {
            foreach(var gridItem in grid)
            {
                foreach(string key in gridItem)
                {
                    if (key != Land && key != Water) return false;
                }
            }

            return true;
        }
    }
}