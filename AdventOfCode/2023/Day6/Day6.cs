namespace AdventOfCode._2023.Day6;

public class Day6
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2023/Day6/input.txt")
            .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(l => l.Skip(1).ToList())
            .ToList();

        var times = input.First();
        var distances = input.Last();

        var result = 1;
        for (var i = 0; i < times.Count; i++)
        {
            var time = int.Parse(times[i]);
            var distance = int.Parse(distances[i]);

            var count = 0;
            for (var j = 0; j < time; j++)
                if ((time - j) * j > distance)
                    count += 1;

            result *= count;
        }

        Console.WriteLine(result);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2023/Day6/input.txt")
            .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(l => l.Skip(1).ToList())
            .ToList();

        var time = long.Parse(string.Join("", input[0]));
        var distance = long.Parse(string.Join("", input[1]));
        
        var count = 0;
        for (var i = 0; i < time; i++)
        {
            if ((time - i) * i <= distance)
            {
                count += 1;
                continue;                
            }
            
            break;
        }

        Console.WriteLine(time + 1 - 2 * count);
    }
}