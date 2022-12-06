namespace AdventOfCode._2022.Day6;

public class Day6
{
    public static void Part1()
    {
        var input = File
            .ReadAllText("2022/Day6/input.txt")
            .Trim();

        var result = -1;
        for (var i = 4; i < input.Length; i++)
        {
            var set = input[(i - 4)..i].ToHashSet();

            if (set.Count != 4) continue;

            result = i;
            break;
        }

        Console.WriteLine(result);
    }

    public static void Part2()
    {
        var input = File
            .ReadAllText("2022/Day6/input.txt")
            .Trim();

        var result = -1;
        for (var i = 14; i < input.Length; i++)
        {
            var set = input[(i - 14)..i].ToHashSet();

            if (set.Count != 14) continue;

            result = i;
            break;
        }

        Console.WriteLine(result);
    }
}