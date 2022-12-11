namespace AdventOfCode._2022.Day11;

public class Day11
{
    public static void Part1()
    {
        var input = File.ReadAllText("2022/Day11/input.txt")
            .Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.TrimEntries)
            .Select(s => s.Split(Environment.NewLine, StringSplitOptions.TrimEntries))
            .ToList();

        var monkeys = Enumerable
            .Range(0, input.Count)
            .Select(i => new Monkey { Id = i })
            .ToList();

        // parse input
        for (var i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            var data = input[i];

            var items = data[1].Split(' ', ',');
            foreach (var s in items)
                if (int.TryParse(s, out var val))
                    monkey.Items.Enqueue(val);

            var operation = data[2].Split(' ');
            monkey.Operation = (operation[3], operation[4], operation[5]);

            var divisibleBy = data[3].Split(' ').Last();
            monkey.DivisibleBy = int.Parse(divisibleBy);

            var ifTrue = data[4].Split(' ').Last();
            monkey.TrueMonkey = int.Parse(ifTrue);

            var ifFalse = data[5].Split(' ').Last();
            monkey.FalseMonkey = int.Parse(ifFalse);
        }

        for (var i = 0; i < 20; i++)
            foreach (var monkey in monkeys)
                while (monkey.Items.Count != 0)
                {
                    var worryLevel = monkey.Items.Dequeue();
                    var (_, op, r) = monkey.Operation;

                    monkey.Inspected++;

                    switch (op, r)
                    {
                        case ("+", "old"):
                            worryLevel += worryLevel;
                            break;
                        case ("+", _):
                            worryLevel += int.Parse(r);
                            break;
                        case ("*", "old"):
                            worryLevel *= worryLevel;
                            break;
                        case ("*", _):
                            worryLevel *= int.Parse(r);
                            break;
                    }

                    worryLevel /= 3;
                    
                    if (worryLevel % monkey.DivisibleBy == 0)
                        monkeys[monkey.TrueMonkey].Items.Enqueue(worryLevel);
                    else
                        monkeys[monkey.FalseMonkey].Items.Enqueue(worryLevel);
                }

        var result = monkeys
            .OrderByDescending(m => m.Inspected)
            .Take(2)
            .Aggregate(1L, (res, m) => res * m.Inspected);

        Console.WriteLine(result);
    }
}

public class Monkey
{
    public int Id { get; set; }
    public Queue<long> Items { get; set; } = new();
    public (string left, string op, string right) Operation { get; set; }
    public long DivisibleBy { get; set; }
    public int TrueMonkey { get; set; }
    public int FalseMonkey { get; set; }
    public long Inspected { get; set; }
}