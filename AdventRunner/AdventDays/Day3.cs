using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day3 : Day
    {
        public static void Run()
        {
            List<string> forest = GetFileContents(nameof(Day3));

            int numberOfValidPasswordsPart1 = global::Day3.Vb.Code.Day3.Part1(forest);
            int numberOfValidPasswordsPart2 = global::Day3.Vb.Code.Day3.Part2(forest);

            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {numberOfValidPasswordsPart1}\r\nPart 2: {numberOfValidPasswordsPart2}";
        }
    }
}