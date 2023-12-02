namespace AoC_2023 {
    internal static class Solutions {
        internal static void DayOne() {
            string[] input = FileReader.ReadFileLines(1);
            int answerOne = 0, answerTwo = 0;

            #region Solution 1
            for (int i = 0; i < input.Length; i++) {
                string row = input[i];

                char first = row.First(char.IsDigit);
                char last = row.Last(char.IsDigit);

                answerOne += int.Parse($"{first}{last}");
            }
            #endregion
            #region Solution 2
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

                answerTwo += int.Parse($"{first}{last}");
            }
            #endregion

            Console.WriteLine($"DayOne 1: {answerOne}");
            Console.WriteLine($"DayOne 2: {answerTwo}");
        }
    }
}
