using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day4 : Day
    {
        public static void Run()
        {
            using TextReader tr = new StreamReader(@$"InputFiles\Day4.txt");

            var passports = new List<string>();
            var currentLine = "";
            var stringBuilder = new StringBuilder();
            while (currentLine != null)
            {
                currentLine = tr.ReadLine();
                if (currentLine != string.Empty)
                {
                    stringBuilder.Append($"{currentLine} ");
                }
                else
                {
                    passports.Add(stringBuilder.ToString().Trim());
                    stringBuilder.Clear();
                }
            }

            passports.Add(stringBuilder.ToString().Trim());

            int numberOfValidPassportsPart1 = FSharp.Code.Day4.part1(passports.AsEnumerable());
            int numberOfValidPassportsPart2 = FSharp.Code.Day4.part2(passports.AsEnumerable());

            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {numberOfValidPassportsPart1}\r\nPart 2: {numberOfValidPassportsPart2}";
        }
    }
}