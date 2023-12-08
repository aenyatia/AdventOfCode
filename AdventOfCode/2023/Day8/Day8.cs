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

    public static void Part2()
    {
        var input = File.ReadAllLines("2023/Day8/input.txt");

        var navigation = input.First();
        var maps = new Dictionary<string, (string left, string right)>();
        foreach (var line in input.Skip(2))
            maps[line[..3]] = (line[7..10], line[12..15]);

        var currents = maps
            .Where(kvp => kvp.Key.EndsWith('A'))
            .Select(kvp => kvp.Key)
            .ToList();

        var steps = currents
            .Select(StepsToLastZ)
            .ToList();

        Console.WriteLine(Lcm(steps));
        return;

        int StepsToLastZ(string node)
        {
            var stepsCount = 0;
            while (node[2] != 'Z')
            {
                node = navigation[stepsCount % navigation.Length] == 'L'
                    ? maps[node].left
                    : maps[node].right;

                stepsCount += 1;
            }

            return stepsCount;
        }

        long Lcm(IList<int> listOfNumbers)
        {
            long lcm = 1;
            var divisor = 2;

            while (true)
            {
                var counter = 0;
                var divisible = false;
                for (var i = 0; i < listOfNumbers.Count; i++)
                {
                    if (listOfNumbers[i] == 1)
                        counter++;

                    if (listOfNumbers[i] % divisor != 0) continue;

                    divisible = true;
                    listOfNumbers[i] /= divisor;
                }

                if (divisible) lcm *= divisor;
                else divisor++;

                if (counter == listOfNumbers.Count)
                    return lcm;
            }
        }
    }
}