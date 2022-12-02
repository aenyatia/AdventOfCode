namespace AdventOfCode._2022.Day2;

public class Day2
{
    public static void Part1()
    {
        var score = File.ReadAllLines("2022/Day2/input.txt")
            .Select(line => line.Split(" "))
            .Sum(GetScorePartOne);

        Console.WriteLine(score);
    }

    public static void Part2()
    {
        var score = File.ReadAllLines("2022/Day2/input.txt")
            .Select(line => line.Split(" "))
            .Sum(GetScorePartTwo);

        Console.WriteLine(score);
    }

    private static int GetScorePartOne(IReadOnlyList<string> args)
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

            _ => throw new ArgumentOutOfRangeException(nameof(args))
        };
    }

    private static int GetScorePartTwo(IReadOnlyList<string> args)
    {
        return (args[0], args[1]) switch
        {
            ("A", "X") => 3 + 0,
            ("B", "X") => 1 + 0,
            ("C", "X") => 2 + 0,

            ("A", "Y") => 1 + 3,
            ("B", "Y") => 2 + 3,
            ("C", "Y") => 3 + 3,

            ("A", "Z") => 2 + 6,
            ("B", "Z") => 3 + 6,
            ("C", "Z") => 1 + 6,

            _ => throw new ArgumentOutOfRangeException(nameof(args))
        };
    }
}