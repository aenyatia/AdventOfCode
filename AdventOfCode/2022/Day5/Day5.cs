using File = System.IO.File;

namespace AdventOfCode._2022.Day5;

public class Day5
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2022/Day5/input.txt");

        var boxes = input
            .Where(s => s.StartsWith('['))
            .Reverse();

        var commands = input
            .Where(s => s.StartsWith("move"))
            .Select(s => s.Split(" "))
            .Select(s => (int.Parse(s[1]), int.Parse(s[3]), int.Parse(s[5])));

        var stacks = Enumerable
            .Repeat(0, 9)
            .Select(s => new Stack<char>())
            .ToList();

        foreach (var box in boxes)
            for (var i = 1; i < box.Length; i += 4)
                if (box[i] != ' ')
                    stacks[i / 4].Push(box[i]);

        foreach (var (count, from, to) in commands)
            for (var i = 0; i < count; i++)
                stacks[to - 1].Push(stacks[from - 1].Pop());

        var result = stacks
            .Select(s => s.Peek());

        Console.WriteLine(string.Concat(result));
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2022/Day5/input.txt");

        var boxes = input
            .Where(s => s.StartsWith('['))
            .Reverse();

        var commands = input
            .Where(s => s.StartsWith("move"))
            .Select(s => s.Split(" "))
            .Select(s => (int.Parse(s[1]), int.Parse(s[3]), int.Parse(s[5])));

        var stacks = Enumerable
            .Repeat(0, 9)
            .Select(s => new Stack<char>())
            .ToList();

        foreach (var box in boxes)
            for (var i = 1; i < box.Length; i += 4)
                if (box[i] != ' ')
                    stacks[i / 4].Push(box[i]);

        foreach (var (count, from, to) in commands)
        {
            var stack = new Stack<char>();

            for (var i = 0; i < count; i++)
                stack.Push(stacks[from - 1].Pop());

            for (var i = 0; i < count; i++)
                stacks[to - 1].Push(stack.Pop());
        }

        var result = stacks
            .Select(s => s.Peek());

        Console.WriteLine(string.Concat(result));
    }
}