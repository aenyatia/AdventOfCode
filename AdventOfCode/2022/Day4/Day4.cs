namespace AdventOfCode._2022.Day4;

public class Day4
{
    public static void Part1()
    {
        var input = File
            .ReadAllLines("2022/Day4/input.txt")
            .Select(line => line.Split('-', ',')
                .Select(int.Parse)
                .ToArray());

        var fullyOverlap =
            (from line in input
             let beginSectionA = line[0]
             let endSectionA = line[1]
             let beginSectionB = line[2]
             let endSectionB = line[3]
             where beginSectionB >= beginSectionA && endSectionB <= endSectionA ||
                   beginSectionB <= beginSectionA && endSectionB >= endSectionA
             select line)
            .Count();

        Console.WriteLine(fullyOverlap);
    }

    public static void Part2()
    {
        var input = File
            .ReadAllLines("2022/Day4/input.txt")
            .Select(line => line.Split('-', ',')
                .Select(int.Parse)
                .ToArray())
            .ToList();

        var notOverlap =
            (from line in input
             let beginSectionA = line[0]
             let endSectionA = line[1]
             let beginSectionB = line[2]
             let endSectionB = line[3]
             where beginSectionB > endSectionA || endSectionB < beginSectionA
             select line)
            .Count();

        Console.WriteLine(input.Count - notOverlap);
    }
}