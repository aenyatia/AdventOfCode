namespace AdventOfCode._2021.Day1;

public class Day1
{
    public static void Part1()
    {
        var input = File
            .ReadAllLines("2021/Day1/input.txt")
            .Select(int.Parse)
            .ToList();

        var count = 0;

        for (var i = 1; i < input.Count; i++)
            if (input[i] > input[i - 1])
                count++;

        Console.WriteLine(count);
    }

    public static void Part2()
    {
        var input = File
            .ReadLines("2021/Day1/input.txt")
            .Select(int.Parse)
            .ToList();

        var count = 0;

        for (var i = 3; i < input.Count; i++)
            if (input[i] > input[i - 3])
                count++;

        Console.WriteLine(count);
    }
}