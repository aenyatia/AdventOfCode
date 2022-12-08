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
}