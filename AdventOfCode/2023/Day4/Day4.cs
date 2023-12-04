namespace AdventOfCode._2023.Day4;

public class Day4
{
    private static readonly char[] Separators = { ':', '|' };

    public static void Part1()
    {
        var input = File.ReadAllLines("2023/Day4/input.txt")
            .Select(l => l.Split(Separators, StringSplitOptions.RemoveEmptyEntries))
            .Select(r => r.Skip(1).ToList())
            .ToList();

        var pointsSum = 0;
        foreach (var line in input)
        {
            var winningNumbers = line
                .First()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            var guessedNumbers = line
                .Last()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Count(number => winningNumbers.Contains(number));

            pointsSum += guessedNumbers == 0 ? 0 : (int)Math.Pow(2, guessedNumbers - 1);
        }

        Console.WriteLine(pointsSum);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2023/Day4/input.txt")
            .Select(l => l.Split(Separators, StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        var dictionary = new Dictionary<int, int>();
        foreach (var line in input)
        {
            var card = int.Parse(line[0].Split(' ').Last());

            var winningNumbers = line[1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            var guessedNumbers = line[2]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Count(number => winningNumbers.Contains(number));

            for (var key = card; key < card + guessedNumbers + 1; key++)
                if (!dictionary.ContainsKey(key)) dictionary[key] = 1;
                else dictionary[key] += 1;

            for (var key = card + 1; key < card + guessedNumbers + 1; key++)
                dictionary[key] += dictionary[card] - 1;
        }

        Console.WriteLine(dictionary.Sum(kvp => kvp.Value));
    }
}