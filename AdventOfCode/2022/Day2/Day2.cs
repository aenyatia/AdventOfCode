namespace AdventOfCode._2022.Day2;

public class Day2
{
    public static void Part1()
    {
        var score = File.ReadAllLines("2022/Day2/input.txt")
            .Select(line => line.Split(" "))
            .Sum(GetScore);

        Console.WriteLine(score);
    }

    private static int GetScore(IReadOnlyList<string> args)
    {
        return (args[0], args[1]) switch
        {
            ("A", "X") => 1 + 3,
            ("A", "Y") => 2 + 6,
            ("A", "Z") => 3 + 0,

            ("B", "X") => 1 + 0,
            ("B", "Y") => 2 + 3,
            ("B", "Z") => 3 + 6,

            ("C", "X") => 1 + 6,
            ("C", "Y") => 2 + 0,
            ("C", "Z") => 3 + 3,

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}