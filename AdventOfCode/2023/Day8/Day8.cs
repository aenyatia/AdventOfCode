namespace AdventOfCode._2023.Day8;

public class Day8
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2023/Day8/input.txt");

        var navigation = input.First();
        var maps = new Dictionary<string, (string left, string right)>();
        foreach (var line in input.Skip(2))
            maps[line[..3]] = (line[7..10], line[12..15]);

        var steps = 0;
        var navIndex = 0;
        var current = "AAA";
        while (current != "ZZZ")
        {
            current = navigation[navIndex] == 'L'
                ? maps[current].left
                : maps[current].right;

            steps += 1;
            navIndex = (navIndex + 1) % navigation.Length;
        }

        Console.WriteLine(steps);
    }
}