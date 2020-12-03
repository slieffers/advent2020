using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day2
    {
        public static void Run()
        {
            using TextReader tr = new StreamReader(@"InputFiles\Day2.txt");
            IEnumerable<string> passwords = 
                tr
                    .ReadToEnd()
                    .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            int numberOfValidPasswords = FSharp.Code.Day2.part1(passwords);

            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {numberOfValidPasswords}\r\nPart 2: {0}";
        }
    }
}