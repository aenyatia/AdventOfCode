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
}