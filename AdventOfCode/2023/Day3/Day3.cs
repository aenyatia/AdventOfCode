namespace AdventOfCode._2023.Day3;

public class Day3
{
    public static void Part1()
    {
        var input = File.ReadAllLines("2023/Day3/input.txt");

        var sum = 0;
        for (var row = 0; row < input.Length; row++)
        {
            var col = 0;
            while (col < input[row].Length)
            {
                var start = col;
                var number = string.Empty;

                while (col < input[row].Length && IsDigit(row, col))
                {
                    number += input[row][col];
                    col++;
                }

                if (string.IsNullOrEmpty(number))
                {
                    col++;
                    continue;
                }

                if (IsSymbol(row, start - 1) || IsSymbol(row, col))
                {
                    sum += int.Parse(number);

                    col++;
                    continue;
                }

                for (var c = start - 1; c < col + 1; c++)
                {
                    if (!IsSymbol(row - 1, c) && !IsSymbol(row + 1, c)) continue;

                    sum += int.Parse(number);
                    break;
                }
            }
        }

        Console.WriteLine(sum);

        return;

        bool IsSymbol(int row, int col)
        {
            if (!IsValidIndex(row, col)) return false;

            return input[row][col] != '.' && !IsDigit(row, col);
        }

        bool IsValidIndex(int row, int col)
        {
            return row >= 0 && row < input.Length &&
                   col >= 0 && col < input[row].Length;
        }

        bool IsDigit(int row, int col) => char.IsDigit(input[row][col]);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("2023/Day3/input.txt");

        var rows = input.Length;
        var cols = input[0].Length;

        var gearRatio = 0;
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (input[row][col] != '*') continue;

                var numbers = new HashSet<int>();
                for (var i = -1; i < 2; i++)
                {
                    if (IsValidIndex(row - 1, col + i) && IsDigit(row - 1, col + i))
                        numbers.Add(ReadNumber(row - 1, col + i));
                    if (IsValidIndex(row + 1, col + i) && IsDigit(row + 1, col + i))
                        numbers.Add(ReadNumber(row + 1, col + i));
                }

                if (IsValidIndex(row, col - 1) && IsDigit(row, col - 1))
                    numbers.Add(ReadNumber(row, col - 1));
                if (IsValidIndex(row, col + 1) && IsDigit(row, col + 1))
                    numbers.Add(ReadNumber(row, col + 1));

                if (numbers.Count == 2) gearRatio += numbers.First() * numbers.Last();
            }
        }

        Console.WriteLine(gearRatio);
        return;

        int ReadNumber(int row, int col)
        {
            var chars = new List<char> { input[row][col] };

            var left = col - 1;
            while (IsValidIndex(row, left) && IsDigit(row, left))
            {
                chars.Insert(0, input[row][left]);
                left--;
            }

            var right = col + 1;
            while (IsValidIndex(row, right) && IsDigit(row, right))
            {
                chars.Add(input[row][right]);
                right++;
            }

            return int.Parse(new string(chars.ToArray()));
        }

        bool IsValidIndex(int row, int col)
        {
            return row >= 0 && row < rows &&
                   col >= 0 && col < cols;
        }

        bool IsDigit(int row, int col) => char.IsDigit(input[row][col]);
    }
}