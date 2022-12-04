namespace AdventOfCode._2021.Day3;

public class Day3
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2021/Day3/input.txt");

        var gammaRate = string.Empty;
        var epsilonRate = string.Empty;

        for (var i = 0; i < input.First().Length; i++)
        {
            var zeroCount = input.Count(n => n[i] == '0');

            if (zeroCount > input.Length / 2)
            {
                gammaRate += "0";
                epsilonRate += "1";
            }
            else
            {
                gammaRate += "1";
                epsilonRate += "0";
            }
        }

        var gammaValue = Convert.ToInt32(gammaRate, 2);
        var epsilonValue = Convert.ToInt32(epsilonRate, 2);

        Console.WriteLine(gammaValue * epsilonValue);
    }
}