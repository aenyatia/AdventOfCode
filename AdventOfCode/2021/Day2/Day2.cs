namespace AdventOfCode._2021.Day2;

public class Day2
{
    public static void Part1()
    {
        var commands = File
            .ReadAllLines("2021/Day2/input.txt")
            .Select(line => line.Split())
            .Select(cmd => (cmd[0], int.Parse(cmd[1])));

        var position = 0;
        var depth = 0;

        foreach (var (command, value) in commands)
        {
            switch (command)
            {
                case "forward":
                    position += value;
                    break;
                case "down":
                    depth += value;
                    break;
                case "up":
                    depth -= value;
                    break;
            }
        }

        Console.WriteLine(position * depth);
    }

    public static void Part2()
    {
        var commands = File
            .ReadAllLines("2021/Day2/input.txt")
            .Select(line => line.Split())
            .Select(cmd => (cmd[0], int.Parse(cmd[1])));

        var position = 0;
        var depth = 0;
        var aim = 0;

        foreach (var (command, value) in commands)
        {
            switch (command)
            {
                case "forward":
                    position += value;
                    depth += aim * value;
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
            }
        }

        Console.WriteLine(position * depth);
    }
}