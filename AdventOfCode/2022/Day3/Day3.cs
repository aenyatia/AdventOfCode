﻿namespace AdventOfCode._2022.Day3;

public class Day3
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2022/Day3/input.txt");

        var itemTypes = new List<char>();

        foreach (var line in input)
        {
            var set = new HashSet<char>();

            for (var i = 0; i < line.Length / 2; i++)
                set.Add(line[i]);

            for (var i = line.Length / 2; i < line.Length; i++)
                if (set.Contains(line[i]))
                {
                    itemTypes.Add(line[i]);
                    break;
                }
        }

        var sum = itemTypes.Sum(i => char.IsLower(i) ? i - 96 : i - 38);

        Console.WriteLine(sum);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2022/Day3/input.txt");

        var itemTypes = new List<char>();

        for (var i = 2; i < input.Length; i += 3)
        {
            var x = input[i - 2].ToHashSet();
            var y = input[i - 1].ToHashSet();
            var z = input[i - 0].ToHashSet();

            itemTypes.AddRange(x.Intersect(y).Intersect(z));
        }

        var sum = itemTypes.Sum(i => char.IsLower(i) ? i - 96 : i - 38);

        Console.WriteLine(sum);
    }

    public static void Part1Ver2()
    {
        var input = File.ReadAllLines("2022/Day3/input.txt");

        var itemTypes =
            from line in input
            let left = line[..(line.Length / 2)]
            let right = line[(line.Length / 2)..]
            let set = left.ToHashSet()
            select right.First(set.Contains);

        var sum = itemTypes.Sum(i => char.IsLower(i) ? i - 96 : i - 38);

        Console.WriteLine(sum);
    }
}