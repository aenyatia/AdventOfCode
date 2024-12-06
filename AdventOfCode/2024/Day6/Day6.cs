namespace AdventOfCode._2024.Day6;

public static class Day6
{
    private const string Path = "2024/Day6/input.txt";

    public static void Part1()
    {
        var board = File.ReadAllLines(Path);

        var current = new Position(0, 0);
        for (var y = 0; y < board.Length; y++)
        for (var x = 0; x < board[y].Length; x++)
            if (board[y][x] == '^')
                current = new Position(x, y);

        var visited = new HashSet<Position> { current };

        var moveDirection = 0;
        Position[] directions = [new(0, -1), new(1, 0), new(0, 1), new(-1, 0)];

        while (true)
        {
            var offset = directions[moveDirection];
            var next = new Position(current.X + offset.X, current.Y + offset.Y);

            if (next.Y < 0 || next.Y >= board.Length ||
                next.X < 0 || next.X >= board[0].Length)
                break;

            if (board[next.Y][next.X] == '.' || board[next.Y][next.X] == '^')
            {
                current = next;
                visited.Add(next);
            }
            else
            {
                moveDirection = (moveDirection + 1) % 4;
            }
        }

        Console.WriteLine($"[Part1] {visited.Count}");
    }

    private record struct Position(int X, int Y);
}