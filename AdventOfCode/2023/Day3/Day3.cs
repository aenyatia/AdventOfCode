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
}