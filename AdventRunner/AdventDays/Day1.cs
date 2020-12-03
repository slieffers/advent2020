using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day1
    {
        public static void Run()
        {
            using TextReader tr = new StreamReader(@"InputFiles\Day1.txt");
            IEnumerable<int> numbers = 
                tr
                    .ReadToEnd()
                    .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            (int part1Num1, int part1Num2) = FSharp.Code.Day1.part1(numbers);
            (int part2Num1, int part2Num2, int part2Num3) = FSharp.Code.Day1.part2(numbers);

            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {part1Num1 * part1Num2}\r\nPart 2: {part2Num1 * part2Num2 * part2Num3}";
        }
    }
}