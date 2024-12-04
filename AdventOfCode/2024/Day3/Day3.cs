using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day3;

public static class Day3
{
    private const string Path = "2024/Day3/input.txt";

    public static void Part1()
    {
        var input = File.ReadAllText(Path);

        var numbers = new List<(int, int)>();

        FindValid(input, numbers);

        var result = numbers.Aggregate(0, (current, number) => current + number.Item1 * number.Item2);

        Console.WriteLine($"[Part1] {result}");
    }

    public static void Part1Ver2()
    {
        var input = File.ReadAllText(Path);

        var mul = 0;
        foreach (Match match in RegexLib.MulMatches(input))
        {
            var num1 = int.Parse(match.Groups[1].Value);
            var num2 = int.Parse(match.Groups[2].Value);
            mul += num1 * num2;
        }

        Console.WriteLine($"[Part1] {mul}");
    }

    public static void Part2()
    {
        var input = File.ReadAllText(Path);

        var numbers = new List<(int, int)>();
        var parts = input.Split("don't()");

        FindValid(parts.First(), numbers);
        foreach (var part in parts.Skip(1))
        {
            var index = part.IndexOf("do()", StringComparison.Ordinal);

            if (index != -1)
                FindValid(part[(index + 4)..], numbers);
        }

        var result = numbers.Aggregate(0, (current, number) => current + number.Item1 * number.Item2);

        Console.WriteLine($"[Part2] {result}");
    }

    public static void Part2Ver2()
    {
        var input = File.ReadAllText(Path);

        var mul = 0;
        var isEnabled = true;
        foreach (Match match in RegexLib.MulAndSwitchMatches(input))
        {
            if (match.Groups["switch"].Value == string.Empty && isEnabled)
            {
                var num1 = int.Parse(match.Groups[1].Value);
                var num2 = int.Parse(match.Groups[2].Value);
                mul += num1 * num2;
            }
            else isEnabled = match.Groups["switch"].Value == "do()";
        }

        Console.WriteLine($"[Part2] {mul}");
    }

    private static void FindValid(string input, List<(int, int)> numbers)
    {
        Span<int> num1 = [0, 0];
        Span<char> num2 = [' ', ' ', ' '];

        var start = input.IndexOf("mul(", StringComparison.Ordinal);
        while (start != -1)
        {
            var i = 0;
            var index = 0;

            num2.Fill(' ');

            while (true)
            {
                var c = input[start + 4 + i];

                if (char.IsDigit(c))
                {
                    num2[index++] = c;
                }

                else if (c == ',')
                {
                    num1[0] = int.Parse(num2);
                    index = 0;
                    num2.Fill(' ');
                }

                else if (c == ')')
                {
                    num1[1] = int.Parse(num2);
                    num2.Fill(' ');

                    numbers.Add((num1[0], num1[1]));

                    break;
                }

                else
                {
                    break;
                }

                i++;
            }

            input = input[(start + 4)..];
            start = input.IndexOf("mul(", StringComparison.Ordinal);
        }
    }
}

public static partial class RegexLib
{
    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex Mul();

    [GeneratedRegex(@"mul\((\d+),(\d+)\)|(?<switch>do\(\)|don't\(\))")]
    private static partial Regex MulAndSwitch();

    public static MatchCollection MulMatches(string input)
        => Mul().Matches(input);

    public static MatchCollection MulAndSwitchMatches(string input)
        => MulAndSwitch().Matches(input);
}