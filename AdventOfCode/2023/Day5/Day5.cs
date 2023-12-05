namespace AdventOfCode._2023.Day5;

public class Day5
{
    public static void Part1()
    {
        var input = File.ReadAllText("2023/Day5/input.txt")
            .Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var seeds = input
            .First()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(long.Parse)
            .ToList();

        foreach (var category in input[1..])
        {
            var map = category
                .Split(Environment.NewLine)[1..]
                .Select(l => l.Split(' '));

            var locationChanged = new List<bool>(Enumerable.Repeat(false, seeds.Count));
            foreach (var line in map)
            {
                var source = long.Parse(line[1]);
                var dest = long.Parse(line[0]);
                var range = long.Parse(line[2]);

                for (var i = 0; i < seeds.Count; i++)
                {
                    if (seeds[i] < source || seeds[i] >= source + range || locationChanged[i])
                        continue;

                    seeds[i] = seeds[i] - source + dest;
                    locationChanged[i] = true;
                }
            }
        }

        Console.WriteLine(seeds.Min());
    }
}