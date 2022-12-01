namespace AdventOfCode._2022.Day1;

public class Day1
{
    public static void Part1()
    {
        var input = File
            .ReadAllLines("2022/Day1/input.txt")
            .Select(line => int.TryParse(line, out var n) ? n : (int?)null);

        var sum = 0;
        var max = 0;
        foreach (var n in input)
        {
            if (n.HasValue)
            {
                sum += n.Value;
                continue;
            }

            if (sum > max)
                max = sum;

            sum = 0;
        }

        Console.WriteLine(max);
    }

    public static void Part2()
    {
        var result = File
            .ReadAllText("2022/Day1/input.txt")
            .Trim()
            .Split("\n\n")
            .Select(line => line
                .Split("\n")
                .Select(int.Parse)
                .Sum())
            .OrderByDescending(s => s)
            .Take(3)
            .Sum();

        Console.WriteLine(result);
    }
}