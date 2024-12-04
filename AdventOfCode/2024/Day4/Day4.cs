namespace AdventOfCode._2024.Day4;

public static class Day4
{
    private const string Path = "2024/Day4/input.txt";

    public static void Part1()
    {
        var input = File.ReadAllLines(Path);
        var count = 0;

        // horizontal
        for (var row = 0; row < input.Length; row++)
        for (var col = 0; col < input[row].Length - 3; col++)
        {
            var hor = $"{input[row][col]}{input[row][col + 1]}{input[row][col + 2]}{input[row][col + 3]}";

            if (IsXMAS(hor)) count++;
        }

        // vertical
        for (var row = 0; row < input.Length - 3; row++)
        for (var col = 0; col < input[row].Length; col++)
        {
            var ver = $"{input[row][col]}{input[row + 1][col]}{input[row + 2][col]}{input[row + 3][col]}";

            if (IsXMAS(ver)) count++;
        }

        // diagonal
        for (var row = 0; row < input.Length - 3; row++)
        for (var col = 0; col < input[row].Length - 3; col++)
        {
            var diag =
                $"{input[row][col]}{input[row + 1][col + 1]}{input[row + 2][col + 2]}{input[row + 3][col + 3]}";
            var antiDiag =
                $"{input[row][col + 3]}{input[row + 1][col + 2]}{input[row + 2][col + 1]}{input[row + 3][col]}";

            if (IsXMAS(diag)) count++;
            if (IsXMAS(antiDiag)) count++;
        }

        Console.WriteLine($"[Part1] {count}");
    }

    private static bool IsXMAS(string input) => input.Contains("XMAS") || input.Contains("SAMX");
}