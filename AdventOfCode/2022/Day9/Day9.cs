namespace AdventOfCode._2022.Day9;

public class Day9
{
    public static void Part1()
    {
        var commands = File
            .ReadAllLines("2022/Day9/input.txt")
            .Select(line => line.Split(" "))
            .Select(cmd => (direction: cmd[0], value: int.Parse(cmd[1])));

        var (headX, headY) = (0, 0);
        var (tailX, tailY) = (0, 0);

        var visited = new HashSet<(int x, int y)>();
        var moves = new Dictionary<string, (int x, int y)>
        {
            { "U", (0, 1) },
            { "D", (0, -1) },
            { "L", (-1, 0) },
            { "R", (1, 0) }
        };

        visited.Add((tailX, tailY));
        foreach (var (direction, count) in commands)
            for (var i = 0; i < count; i++)
            {
                headX += moves[direction].x;
                headY += moves[direction].y;

                if (Math.Abs(headX - tailX) <= 1 &&
                    Math.Abs(headY - tailY) <= 1)
                    continue;

                if (Math.Abs(headX - tailX) > 1)
                {
                    if (headY == tailY)
                    {
                        tailX += moves[direction].x;
                        tailY += moves[direction].y;
                    }
                    else
                    {
                        tailX += moves[direction].x;
                        tailY = headY;
                    }
                }

                if (Math.Abs(headY - tailY) > 1)
                {
                    if (headX == tailX)
                    {
                        tailX += moves[direction].x;
                        tailY += moves[direction].y;
                    }
                    else
                    {
                        tailX = headX;
                        tailY += moves[direction].y;
                    }
                }

                visited.Add((tailX, tailY));
            }

        Console.WriteLine(visited.Count);
    }
}