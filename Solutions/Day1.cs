namespace AoC_2023.Solutions {
    internal static class DayOne {
        internal static void SolveOne() {
            string[] input = FileReader.ReadFileLines(1);
            int answer = 0;

            foreach (string row in input) {
                char first = row.First(char.IsDigit);
                char last = row.Last(char.IsDigit);

                answer += int.Parse($"{first}{last}");
            }

            Console.WriteLine($"DayOne 1: {answer}");
        }

        internal static void SolveTwo() {
            string[] input = FileReader.ReadFileLines(1);
            int answer = 0;

            for (int i = 0; i < input.Length; i++) {
                string row = input[i];

                row = row.Replace("one", "o1e");
                row = row.Replace("two", "t2o");
                row = row.Replace("three", "t3e");
                row = row.Replace("four", "f4r");
                row = row.Replace("five", "f5e");
                row = row.Replace("six", "s6x");
                row = row.Replace("seven", "s7n");
                row = row.Replace("eight", "e8t");
                row = row.Replace("nine", "n9e");

                char first = row.First(char.IsDigit);
                char last = row.Last(char.IsDigit);

                answer += int.Parse($"{first}{last}");
            }

            Console.WriteLine($"DayOne 2: {answer}");
        }

        internal static void SolveBoth() {
            SolveOne();
            SolveTwo();
        }
    }
}
