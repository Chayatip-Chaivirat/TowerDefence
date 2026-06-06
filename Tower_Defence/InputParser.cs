using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;
using System;
namespace Tower_Defence
{
    public static class InputParser
    {
        // Parse string to int
        public static int ParseInt(string input)
        {
            System.Diagnostics.Debug.WriteLine("parse int: " + input);
            int x;
            if (!int.TryParse(input, out x)) { Console.WriteLine("Failed to parse integer: " + input); }
            System.Diagnostics.Debug.WriteLine("Parsed int: " + x.ToString());
            return x;
        }

    // Parse sequence of comma-separated integers from string to an array of ints
    public static int[] parseInts(string input)
        {
            string[] strings = input.Split(',');
            int [] result = new int[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                result[i] = ParseInt(strings[i]);
            }
            return result;
        }
    }
}