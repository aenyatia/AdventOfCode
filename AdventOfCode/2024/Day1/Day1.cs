namespace AdventOfCode._2024.Day1;

public static class Day1
{
    private const string Path = "2024/Day1/input.txt";

    public static void Part1()
    {
        var input = File.ReadAllLines(Path)
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())
            .ToArray();

        var leftNumbers = input.Select(pair => pair[0]).Order().ToArray();
        var rightNumbers = input.Select(pair => pair[1]).Order().ToArray();

        var totalDistance = leftNumbers.Zip(rightNumbers, (left, right)
            => Math.Abs(left - right)).Sum();

        Console.WriteLine($"[Part1] Total distance: {totalDistance}");
    }

    public static void Part2()
    {
        var input = File.ReadAllLines(Path)
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())
            .ToArray();

        var leftNumbers = input.Select(pair => pair[0]).Order().ToArray();
        var rightNumbers = input.Select(pair => pair[1]).Order().ToArray();

        var similarityDict = rightNumbers.GroupBy(n => n)
            .ToDictionary(g => g.Key, g => g.Count());

        var similarityScore = leftNumbers.Where(n => similarityDict.ContainsKey(n))
            .Sum(n => n * similarityDict[n]);

        Console.WriteLine($"[Part2] Similarity Score: {similarityScore}");
    }
}