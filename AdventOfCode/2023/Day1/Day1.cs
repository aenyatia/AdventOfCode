namespace AdventOfCode._2023.Day1;

public class Day1
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2023/Day1/input.txt");

        var sum = 0;
        foreach (var line in input)
        {
            var digits = new char[2];

            for (var i = 0; digits[0] == '\0'; i++)
                if (char.IsDigit(line[i]))
                    digits[0] = line[i];

            for (var i = line.Length - 1; digits[1] == '\0'; i--)
                if (char.IsDigit(line[i]))
                    digits[1] = line[i];

            sum += int.Parse(digits);
        }

        Console.WriteLine(sum);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2023/Day1/input.txt");
        var numberTable = new Dictionary<string, int>()
        {
            { "zero", '0' }, { "one", '1' }, { "two", '2' }, { "three", '3' }, { "four", '4' },
            { "five", '5' }, { "six", '6' }, { "seven", '7' }, { "eight", '8' }, { "nine", '9' },
        };

        var sum = 0;
        foreach (var line in input)
        {
            var digits = new char[2];

            for (var i = 0; digits[0] == '\0'; i++)
            {
                if (char.IsDigit(line[i]))
                    digits[0] = line[i];

                foreach (var (key, value) in numberTable)
                {
                    if (i < line.Length - key.Length && line[i..(i + key.Length)] == key)
                        digits[0] = (char)value;
                }
            }

            for (var i = line.Length - 1; digits[1] == '\0'; i--)
            {
                if (char.IsDigit(line[i]))
                    digits[1] = line[i];

                foreach (var (key, value) in numberTable)
                {
                    if (i <= line.Length - key.Length && line[i..(i + key.Length)] == key)
                        digits[1] = (char)value;
                }
            }

            sum += int.Parse(digits);
        }

        Console.WriteLine(sum);
    }
}