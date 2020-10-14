using System;
using System.Collections.Generic;
using System.Linq;

Console.SetWindowSize(150, 60);
Dictionary<string, int> data = new Dictionary<string, int>();

string[] cols = Console.ReadLine().Split('\t');
int groups = Array.IndexOf(cols, args[0]);
int values = Array.IndexOf(cols, args[1]);
int numberOfLines = int.Parse(args[2]);

string line;
while ((line = Console.ReadLine()) != null)
{
    cols = line.Split('\t');
    string group = cols[groups];
    int value = Convert.ToInt32(cols[values]);

    if (data.Keys.Contains(group)) data[group] += value;
    else data.Add(group, value);
}

data = data.OrderByDescending(v => v.Value).ToDictionary(v => v.Key, v => v.Value);

int max = data.Values.Max();
int i = 0;

foreach(var v in data)
{
    if (i == Math.Min(data.Count, numberOfLines)) break;

    Console.Write($"{v.Key,35} |");
    ConsoleColor consoleColor = Console.BackgroundColor;
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine(new string(' ', (int) Math.Ceiling(v.Value * 100.0 / max)));
    Console.BackgroundColor = consoleColor;
    i++;
}

//Problem wurde mit der Hilfe von Steininger Markus gelöst

