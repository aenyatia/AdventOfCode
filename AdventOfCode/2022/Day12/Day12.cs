namespace AdventOfCode._2022.Day12;

public class Day12
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2022/Day12/input.txt");

        var start = (0, 0);
        var end = (0, 0);

        for (var x = 0; x < input.Length; x++)
            for (var y = 0; y < input.First().Length; y++)
            {
                if (input[x][y] == 'S')
                    start = (x, y);
                if (input[x][y] == 'E')
                    end = (x, y);
            }

        Console.WriteLine(ShortestPath(input, start, end));
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2022/Day12/input.txt");
        var depths = new HashSet<int>();

        var starts = new HashSet<(int x, int y)>();
        var end = (0, 0);

        for (var x = 0; x < input.Length; x++)
            for (var y = 0; y < input.First().Length; y++)
            {
                if (input[x][y] == 'a') starts.Add((x, y));
                if (input[x][y] == 'E') end = (x, y);
            }

        foreach (var depth in starts
                     .Select(start => ShortestPath(input, start, end))
                     .Where(depth => depth > 0))
            depths.Add(depth);

        Console.WriteLine(depths.Min());
    }

    public static int ShortestPath(IList<string> input, (int x, int y) start, (int x, int y) end)
    {
        var visited = new HashSet<(int x, int y)>();
        var queue = new PriorityQueue<(int x, int y), int>();

        queue.Enqueue((start.x, start.y), 0);

        while (queue.Count > 0)
        {
            queue.TryDequeue(out var position, out var depth);

            if (visited.Contains((position.x, position.y)))
                continue;

            visited.Add((position.x, position.y));

            if (position == end)
                return depth;

            foreach (var (x, y) in GetNeighbors(input, position))
                queue.Enqueue((x, y), depth + 1);
        }

        return -1;
    }

    private static int GetHeight(char c)
    {
        return c switch
        {
            'S' => 0,
            'E' => 25,
            _ => c - 96
        };
    }

    private static IEnumerable<(int x, int y)> GetNeighbors(IList<string> input, (int x, int y) position)
    {
        var vectors = new HashSet<(int x, int y)> { (1, 0), (0, 1), (-1, 0), (0, -1) };

        foreach (var (x, y) in vectors)
        {
            var newX = position.x + x;
            var newY = position.y + y;

            if (newX < 0 || newX >= input.Count)
                continue;

            if (newY < 0 || newY >= input.First().Length)
                continue;

            var currentChar = input[position.x][position.y];
            var newChar = input[newX][newY];

            if (GetHeight(currentChar) >= GetHeight(newChar) - 1)
                yield return (newX, newY);
        }
    }
}