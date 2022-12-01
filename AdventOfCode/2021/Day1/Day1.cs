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
}