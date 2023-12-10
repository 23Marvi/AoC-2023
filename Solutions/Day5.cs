using System;
using System.Text;

namespace AoC_2023.Solutions {
    internal static class Day5 {
        internal static void SolveOne() {
            string input = FileReader.ReadFileAsString(5);
            long answer = 0;

            string[] maps = input.Split("\n").Where(map => !string.IsNullOrWhiteSpace(map)).ToArray();
            long[] convertables = maps[0].Split(": ")[1].Split(" ").Select(seed => long.Parse(seed)).ToArray();
            long[] dontConvert = new long[convertables.Length];
            maps = maps.Skip(1).ToArray();

            foreach (string map in maps) {
                if (!long.TryParse(map[0].ToString(), out long res)) {
                    dontConvert = new long[dontConvert.Length];
                    continue;
                }
                long[] values = map.Split(" ").Select(value => long.Parse(value)).ToArray();

                for (int i = 0; i < convertables.Length; i++) {
                    long convertable = convertables[i];

                    if (convertable >= values[1] && convertable <= values[1] + values[2] && dontConvert[i] == 0) {
                        long difference = convertable - values[1];
                        convertables[i] = values[0] + difference;
                        dontConvert[i] = convertable;
                    }
                }
            }

            answer = convertables.Min();

            Console.WriteLine($"Day5 1: {answer}");
        }

        internal static void SolveTwo() {
            string[] input = FileReader.ReadFileLines(5);
            long answer = long.MaxValue;

            List<List<long[]>> maps = new();
            foreach (string line in input.Skip(2)) {
                if (string.IsNullOrEmpty(line)) continue;
                else if (!int.TryParse(line[0].ToString(), out int _)) {
                    maps.Add(new());
                } else {
                    long[] values = line.Split(" ").Select(value => long.Parse(value)).ToArray();
                    long[] parsedValues = new long[3];
                    parsedValues[0] = values[1];
                    parsedValues[1] = values[1] + values[2] - 1;
                    parsedValues[2] = values[0] - values[1];
                    maps.Last().Add(parsedValues);
                }
            }

            long[] seeds = input[0].Split(": ")[1].Split(" ").Select(seed => long.Parse(seed)).ToArray();
            List<long[]> convertables = new();
            for (int i = 0; i < seeds.Length; i += 2) {
                convertables.Add(new long[2] { seeds[i], seeds[i] + seeds[i + 1] });
            }

            foreach (List<long[]> map in maps) {
                List<long[]> orderedMaps = map.OrderBy(subMap => subMap[0]).ToList();
                List<long[]> newConvertables = new();

                foreach (long[] c in convertables) {
                    long[] convertable = c;

                    foreach (long[] subMap in orderedMaps) {
                        if (convertable[0] < subMap[0]) {
                            newConvertables.Add(new long[2] { convertable[0], Math.Min(convertable[1], subMap[0] - 1) });
                            convertable[0] = subMap[0];

                            if (convertable[0] > subMap[1]) break;
                        }

                        if (convertable[0] <= subMap[1]) {
                            newConvertables.Add(new long[2] { convertable[0] + subMap[2], Math.Min(convertable[1], subMap[1]) + subMap[2] });
                            convertable[0] = subMap[1] + 1;

                            if (convertable[0] > subMap[1]) break;
                        }
                    }
                    if (convertable[0] <= convertable[1]) newConvertables.Add(convertable);
                }
                convertables = newConvertables;
            }

            answer = convertables.Min(convertable => convertable[0]);

            Console.WriteLine($"Day5 2: {answer}");
        }

        internal static void SolveBoth() {
            SolveOne();
            SolveTwo();
        }
    }
}
