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
}