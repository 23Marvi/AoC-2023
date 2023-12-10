using System.Drawing;

namespace AoC_2023.Solutions {
    internal class Day3 {
        internal static void SolveOne() {
            string[] input = FileReader.ReadFileLines(3);
            int answer = 0;

            for (int y = 0; y < input.Length; y++) {
                string row = input[y];
                string number = "";
                bool valid = false;

                for (int x = 0; x < row.Length; x++) {
                    char current = row[x];

                    if (char.IsDigit(current)) {
                        number += current;
                        if (!valid) valid = NearChar(input, y, x, c => !char.IsLetterOrDigit(c) && c != '.') != null;
                    } else {
                        if (valid) answer += int.Parse(number);
                        number = "";
                        valid = false;
                    }
                }

                if (valid) answer += int.Parse(number);
            }

            Console.WriteLine($"Day3 1: {answer}");
        }

        internal static void SolveTwo() {
            string[] input = FileReader.ReadFileLines(3);
            int answer = 0;

            Dictionary<Point, List<int>> gearValues = new();

            for (int y = 0; y < input.Length; y++) {
                string row = input[y];
                string number = "";
                Point? coord = null;

                for (int x = 0; x < row.Length; x++) {
                    char current = row[x];

                    if (char.IsDigit(current)) {
                        number += current;
                        Point? gearCoord = NearChar(input, y, x, c => c == '*');

                        if (gearCoord != null && gearCoord.HasValue) {
                            coord = gearCoord;
                            if (!gearValues.ContainsKey(gearCoord.Value)) gearValues.Add(gearCoord.Value, new());
                        }
                    } else {
                        if (coord != null) gearValues[coord.Value].Add(int.Parse(number));
                        number = "";
                        coord = null;
                    }
                }

                if (coord != null) gearValues[coord.Value].Add(int.Parse(number));
            }

            foreach (KeyValuePair<Point, List<int>> gear in gearValues) {
                if (gear.Value.Count == 2) {
                    answer += gear.Value.Aggregate((current, next) => current * next);
                }
            }

            Console.WriteLine($"Day3 2: {answer}");
        }

        internal static void SolveBoth() {
            SolveOne();
            SolveTwo();
        }

        private static Point? NearChar(string[] input, int y1, int x1, Func<char, bool> condition) {
            for (int y = y1 - 1; y < y1 + 2; y++) {
                for (int x = x1 - 1; x < x1 + 2; x++) {
                    if (y < 0 || y > input.Length - 1 || x < 0 || x > input[y].Length - 1 || (y == y1 && x == x1)) continue;
                    if (condition(input[y][x])) return new Point(x, y);
                }
            }
            return null;
        }
    }
}
