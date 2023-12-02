namespace AdventOfCode._2023.Day2;

public class Day2
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2023/Day2/input.txt")
            .Select(l => l.Split(':', ';'));

        var games = new List<Game>();
        foreach (var line in input)
        {
            var id = int.Parse(line.First().Remove(0, 5));
            var redCubes = new List<int>();
            var greenCubes = new List<int>();
            var blueCubes = new List<int>();

            foreach (var item in line.Skip(1))
            foreach (var c in item.Split(','))
            {
                var cube = c.Trim().Split(' ');

                switch (cube.Last())
                {
                    case "red":
                        redCubes.Add(int.Parse(cube.First()));
                        break;
                    case "green":
                        greenCubes.Add(int.Parse(cube.First()));
                        break;
                    case "blue":
                        blueCubes.Add(int.Parse(cube.First()));
                        break;
                }
            }

            games.Add(new Game(id, redCubes, greenCubes, blueCubes));
        }

        const int possibleRedCubes = 12;
        const int possibleGreenCubes = 13;
        const int possibleBlueCubes = 14;

        var gameSum = games
            .Where(
                game => possibleRedCubes >= (game.RedCubes.Count != 0 ? game.RedCubes.Max() : 0) &&
                        possibleGreenCubes >= (game.GreenCubes.Count != 0 ? game.GreenCubes.Max() : 0) &&
                        possibleBlueCubes >= (game.BlueCubes.Count != 0 ? game.BlueCubes.Max() : 0))
            .Sum(game => game.Id);

        Console.WriteLine(gameSum);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2023/Day2/input.txt")
            .Select(l => l.Split(':', ';'));

        var games = new List<Game>();
        foreach (var line in input)
        {
            var id = int.Parse(line.First().Remove(0, 5));
            var redCubes = new List<int>();
            var greenCubes = new List<int>();
            var blueCubes = new List<int>();

            foreach (var item in line.Skip(1))
            foreach (var c in item.Split(','))
            {
                var cube = c.Trim().Split(' ');

                switch (cube.Last())
                {
                    case "red":
                        redCubes.Add(int.Parse(cube.First()));
                        break;
                    case "green":
                        greenCubes.Add(int.Parse(cube.First()));
                        break;
                    case "blue":
                        blueCubes.Add(int.Parse(cube.First()));
                        break;
                }
            }

            games.Add(new Game(id, redCubes, greenCubes, blueCubes));
        }

        var gameSum = games.Sum(game =>
            (game.RedCubes.Count != 0 ? game.RedCubes.Max() : 1) *
            (game.GreenCubes.Count != 0 ? game.GreenCubes.Max() : 1) *
            (game.BlueCubes.Count != 0 ? game.BlueCubes.Max() : 1));

        Console.WriteLine(gameSum);
    }
}

public record Game(int Id, List<int> RedCubes, List<int> GreenCubes, List<int> BlueCubes);