namespace AdventOfCode._2024.Day2;

public static class Day2
{
    private const string Path = "2024/Day2/input.txt";

    public static void Part1()
    {
        var input = File.ReadAllLines(Path)
            .Select(line => line.Split(' ')
                .Select(int.Parse).ToArray())
            .ToArray();

        var safeReports = input.Count(IsSafe);

        Console.WriteLine($"[Part1] {safeReports}");
    }

    public static void Part2()
    {
        var input = File.ReadAllLines(Path)
            .Select(line => line.Split(' ')
                .Select(int.Parse).ToArray())
            .ToArray();

        var safeReports = input.Count(level => level
            .Select((_, i) => (int[]) [..level[..i], ..level[(i + 1)..]])
            .Any(IsSafe));

        Console.WriteLine($"[Part2] {safeReports}");
    }

    public static void Part2Ver2()
    {
        var input = File.ReadAllLines(Path)
            .Select(line => line.Split(' ')
                .Select(int.Parse).ToArray())
            .ToArray();

        var safeReports = 0;
        foreach (Span<int> level in input)
        {
            for (var i = 0; i < level.Length; i++)
            {
                Span<int> subLevel = [..level[..i], ..level[(i + 1)..]];

                if (!IsSafe(subLevel)) continue;

                safeReports++;
                break;
            }
        }

        Console.WriteLine($"[Part2] {safeReports}");
    }

    private static bool IsSafe(int[] level)
    {
        return IsSafe(level.AsSpan());
    }

    private static bool IsSafe(Span<int> level)
    {
        var diff = level[1] - level[0];

        switch (diff)
        {
            case 1 or 2 or 3:
            {
                for (var i = 1; i < level.Length; i++)
                    if (level[i] - level[i - 1] is not (1 or 2 or 3))
                        return false;

                return true;
            }
            case -1 or -2 or -3:
            {
                for (var i = 1; i < level.Length; i++)
                    if (level[i] - level[i - 1] is not (-1 or -2 or -3))
                        return false;

                return true;
            }

            default:
                return false;
        }
    }
}