namespace AdventOfCode._2022.Day10;

public class Day10
{
    public static void Part1()
    {
        var instructions = File.ReadAllLines("2022/Day10/input.txt");

        Console.WriteLine(new CpuPart1().Execute(instructions));
    }

    public static void Part2()
    {
        var instructions = File.ReadAllLines("2022/Day10/input.txt");
        var screen = new CpuPart2().Execute(instructions).Chunk(40);

        foreach (var line in screen)
        {
            foreach (var c in line)
                Console.Write(c);

            Console.WriteLine();
        }
    }
}

public class CpuPart1
{
    private readonly ISet<int> _interestingCycles = new HashSet<int> { 20, 60, 100, 140, 180, 220 };

    private int _cycle;
    private int _x = 1;
    private int _signalStrength;

    public int Execute(IEnumerable<string> instructions)
    {
        foreach (var instruction in instructions)
        {
            var parts = instruction.Split(" ");

            if (parts[0] == "noop")
            {
                _cycle++;
                UpdateSignalStrength();
            }
            else
            {
                _cycle++;
                UpdateSignalStrength();

                _cycle++;
                UpdateSignalStrength();

                _x += int.Parse(parts[1]);
            }
        }

        return _signalStrength;
    }

    private void UpdateSignalStrength()
    {
        if (_interestingCycles.Contains(_cycle))
            _signalStrength += _cycle * _x;
    }
}

public class CpuPart2
{
    private readonly IList<char> _screen = new List<char>();

    private int _cycle;
    private int _x = 1;
    private int _sprite = 1;

    public IEnumerable<char> Execute(IEnumerable<string> instructions)
    {
        foreach (var instruction in instructions)
        {
            var parts = instruction.Split(" ");

            if (parts[0] == "noop")
            {
                _cycle++;
                UpdateScreen();
            }
            else
            {
                _cycle++;
                UpdateScreen();

                _cycle++;
                UpdateScreen();

                _x += int.Parse(parts[1]);
                _sprite = _x;
            }
        }

        return _screen;
    }

    private void UpdateScreen()
    {
        var pixel = (_cycle - 1) % 40;

        if (_sprite >= pixel - 1 && _sprite <= pixel + 1) _screen.Add('#');
        else _screen.Add(' ');
    }
}