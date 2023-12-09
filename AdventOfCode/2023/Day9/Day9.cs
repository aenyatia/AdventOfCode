using System.Collections.ObjectModel;

namespace AdventOfCode._2023.Day9;

public class Day9
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2023/Day9/input.txt")
            .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList())
            .ToList();

        var resultParts = new List<int>();
        foreach (var history in input)
        {
            var allZeros = false;
            var repeat = 0;

            while (!allZeros)
            {
                allZeros = true;

                for (var i = 0; i < history.Count - 1 - repeat; i++)
                {
                    var diff = history[i + 1] - history[i];

                    history[i] = diff;

                    if (diff != 0) allZeros = false;
                }

                repeat++;
            }

            resultParts.Add(history.Sum());
        }

        Console.WriteLine(resultParts.Sum());
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2023/Day9/input.txt")
            .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList())
            .ToList();

        var resultParts = new List<int>();
        foreach (var history in input)
        {
            var allZeros = false;
            var repeat = 0;

            while (!allZeros)
            {
                allZeros = true;

                for (var i = history.Count - 1; i > 0 + repeat; i--)
                {
                    var diff = history[i] - history[i - 1];

                    history[i] = diff;

                    if (diff != 0) allZeros = false;
                }

                repeat++;
            }

            var result = 0;
            for (var i = history.Count - 1; i >= 0; i--)
                result = history[i] - result;

            resultParts.Add(result);
        }

        Console.WriteLine(resultParts.Sum());
    }
}