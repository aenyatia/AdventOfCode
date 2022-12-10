namespace AdventOfCode._2022.Day10;

public class Day10
{
    public static void Part1()
    {
        var instructions = File.ReadAllLines("2022/Day10/input.txt");

        Console.WriteLine(new CpuPart1().Execute(instructions));
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