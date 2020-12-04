using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day2 : Day
    {
        public static void Run()
        {
            IEnumerable<string> passwords = GetFileContents(nameof(Day2));

            int numberOfValidPasswordsPart1= FSharp.Code.Day2.part1(passwords);
            int numberOfValidPasswordsPart2= FSharp.Code.Day2.part2(passwords);

            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {numberOfValidPasswordsPart1}\r\nPart 2: {numberOfValidPasswordsPart2}";
        }
    }
}