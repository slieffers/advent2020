using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;
using AdventRunner.InputFiles;

namespace AdventRunner.AdventDays
{
    public class Day1 : Day
    {
        public static void Run()
        {
            List<int> numbers = GetFileContents(nameof(Day1))
                    .Select(int.Parse)
                    .ToList();

            (int part1Num1, int part1Num2) = FSharp.Code.Day1.part1(numbers);
            (int part2Num1, int part2Num2, int part2Num3) = FSharp.Code.Day1.part2(numbers);

            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {part1Num1 * part1Num2}\r\nPart 2: {part2Num1 * part2Num2 * part2Num3}";
        }
    }
}