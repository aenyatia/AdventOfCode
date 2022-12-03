namespace AdventOfCode._2022.Day3;

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
}