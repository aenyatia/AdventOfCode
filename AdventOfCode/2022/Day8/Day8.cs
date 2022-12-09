namespace AdventOfCode._2022.Day8;

public class Day8
{
    public static void Part1()
    {
        var input = File
            .ReadAllLines("2022/Day8/input.txt")
            .Select(line => line
                .Select(c => (int)char.GetNumericValue(c))
                .ToList())
            .ToList();

        var rows = input.Count;
        var cols = input.First().Count;

        var visibleTrees = 0;
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                var treeHeight = input[row][col];

                if (row == 0 || col == 0 || row == rows - 1 || col == cols - 1)
                    visibleTrees++;

                else if (input[row].GetRange(0, col).Max() < treeHeight)
                    visibleTrees++;

                else if (input[row].GetRange(col + 1, cols - col - 1).Max() < treeHeight)
                    visibleTrees++;

                else if (input.GetRange(0, row).Select(n => n[col]).Max() < treeHeight)
                    visibleTrees++;

                else if (input.GetRange(row + 1, rows - row - 1).Select(n => n[col]).Max() < treeHeight)
                    visibleTrees++;
            }
        }

        Console.WriteLine(visibleTrees);
    }

    public static void Part2()
    {
        var input = File
            .ReadAllLines("2022/Day8/input.txt")
            .Select(line => line
                .Select(c => (int)char.GetNumericValue(c))
                .ToList())
            .ToList();

        var rows = input.Count;
        var cols = input.First().Count;
        var maxVisibleTrees = 0;

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                var treeHeight = input[row][col];
                var (left, right, up, down) = (0, 0, 0, 0);

                for (var i = col - 1; i >= 0; i--)
                {
                    if (input[row][i] < treeHeight)
                    {
                        left++;
                        continue;
                    }

                    if (input[row][i] == treeHeight)
                        left++;

                    break;
                }

                for (var i = col + 1; i < cols; i++)
                {
                    if (input[row][i] < treeHeight)
                    {
                        right++;
                        continue;
                    }

                    if (input[row][i] == treeHeight)
                        right++;

                    break;
                }

                for (var i = row - 1; i >= 0; i--)
                {
                    if (input[i][col] < treeHeight)
                    {
                        up++;
                        continue;
                    }

                    if (input[i][col] == treeHeight)
                        up++;

                    break;
                }

                for (var i = row + 1; i < rows; i++)
                {
                    if (input[i][col] < treeHeight)
                    {
                        down++;
                        continue;
                    }

                    if (input[i][col] == treeHeight)
                        down++;

                    break;
                }

                if (left * right * up * down > maxVisibleTrees)
                    maxVisibleTrees = left * right * up * down;
            }
        }

        Console.WriteLine(maxVisibleTrees);
    }

    public static void Part1Ver2()
    {
        var input = File
            .ReadAllLines("2022/Day8/input.txt")
            .Select(line => line
                .Select(c => (int)char.GetNumericValue(c))
                .ToList())
            .ToList();

        var rows = input.Count;
        var cols = input.First().Count;

        var map = new Dictionary<(int row, int col), Heights>();

        for (var n = 0; n < rows; n++)
        {
            for (int left = 0, right = rows - 1; left < rows; left++, right--)
            {
                var leftKey = (n, left);
                var rightKey = (n, right);
                var upKey = (left, n);
                var downKey = (right, n);

                if (!map.ContainsKey(leftKey)) map.Add(leftKey, new Heights());
                if (!map.ContainsKey(rightKey)) map.Add(rightKey, new Heights());
                if (!map.ContainsKey(upKey)) map.Add(upKey, new Heights());
                if (!map.ContainsKey(downKey)) map.Add(downKey, new Heights());

                if (left == 0)
                {
                    map[leftKey].Left = input[n][left];
                    map[rightKey].Right = input[n][right];
                    map[upKey].Up = input[left][n];
                    map[downKey].Down = input[right][n];
                    continue;
                }

                map[leftKey].Left = Math.Max(map[(n, left - 1)].Left, input[n][left]);
                map[rightKey].Right = Math.Max(map[(n, right + 1)].Right, input[n][right]);
                map[upKey].Up = Math.Max(map[(left - 1, n)].Up, input[left][n]);
                map[downKey].Down = Math.Max(map[(right + 1, n)].Down, input[right][n]);
            }
        }

        var visibleTrees = 4 * rows - 4;
        for (var row = 1; row < rows - 1; row++)
            for (var col = 1; col < cols - 1; col++)
            {
                var value = input[row][col];
                var left = (row, col - 1);
                var right = (row, col + 1);
                var up = (row - 1, col);
                var down = (row + 1, col);

                if (map[left].Left < value ||
                    map[right].Right < value ||
                    map[up].Up < value ||
                    map[down].Down < value)
                    visibleTrees++;
            }

        Console.WriteLine(visibleTrees);
    }
}

public class Heights
{
    public int Left { get; set; }
    public int Right { get; set; }
    public int Up { get; set; }
    public int Down { get; set; }
}