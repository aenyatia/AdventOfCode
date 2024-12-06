namespace AdventOfCode._2024.Day5;

public static class Day5
{
    private const string Path = "2024/Day5/input.txt";

    public static void Part1()
    {
        var input = File.ReadAllLines(Path);

        var orderingPages = new Dictionary<int, HashSet<int>>();
        var pagesList = new List<int[]>();

        // parse page ordering rules
        var i = 0;
        while (input[i] != string.Empty)
        {
            var n1 = int.Parse(input[i].AsSpan()[..2]);
            var n2 = int.Parse(input[i].AsSpan()[3..]);

            i++;

            if (orderingPages.TryGetValue(n1, out var value))
                value.Add(n2);
            else
                orderingPages.Add(n1, [n2]);
        }

        // parse pages to produce in each update
        foreach (var line in input.Skip(i + 1))
            pagesList.Add(line.Split(',').Select(int.Parse).ToArray());

        var sumOfMiddlePages = pagesList
            .Where(pages => ArePagesValid(pages, orderingPages))
            .Sum(pages => pages[pages.Length / 2]);

        Console.WriteLine($"[Part1] {sumOfMiddlePages}");
    }

    private static bool ArePagesValid(int[] pages, Dictionary<int, HashSet<int>> orderingPages)
    {
        for (var i = 0; i < pages.Length - 1; i++)
        {
            var page = pages[i];
            if (!orderingPages.TryGetValue(page, out var pageOrder))
                return false;

            for (var j = i + 1; j < pages.Length; j++)
                if (!pageOrder.Contains(pages[j]))
                    return false;
        }

        return true;
    }
}