namespace AoC_2023 {
    internal static class Solutions {
        internal static void DayOne() {
            string[] input = FileReader.ReadFileLines(1);
            int answerOne = 0, answerTwo = 0;

            #region Solution 1
            foreach (string row in input) {
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

        internal static void DayTwo() {
            string[] input = FileReader.ReadFileLines(2);
            int answerOne = 0, answerTwo = 0;

            #region Solution 1
            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;

            foreach (string game in input) {
                string gameId = game.Split(":")[0].Split(" ")[1];
                string[] colourAndDigits = game.Split(" ").Skip(2).ToArray();
                bool possible = true;

                int amount = 0;
                for (int i = 0; i < colourAndDigits.Length; i++) {
                    if (i % 2 == 0) {
                        amount = int.Parse(colourAndDigits[i]);
                    } else {
                        char colour = colourAndDigits[i][0];

                        if ((colour == 'r' && amount > maxRed) || (colour == 'g' && amount > maxGreen) || (colour == 'b' && amount > maxBlue)) {
                            possible = false;
                            break;
                        }
                    }
                }

                if (possible) {
                    answerOne += int.Parse(gameId);
                }
            }
            #endregion
            #region Solution 2
            foreach (string game in input) {
                string gameId = game.Split(":")[0].Split(" ")[1];
                string[] colourAndDigits = game.Split(" ").Skip(2).ToArray();

                int minRed = 0;
                int minGreen = 0;
                int minBlue = 0;

                int amount = 0;
                for (int i = 0; i < colourAndDigits.Length; i++) {
                    if (i % 2 == 0) {
                        amount = int.Parse(colourAndDigits[i]);
                    } else {
                        char colour = colourAndDigits[i][0];

                        if (colour == 'r' && amount > minRed) {
                            minRed = amount;
                        } else if (colour == 'g' && amount > minGreen) {
                            minGreen = amount;
                        } else if (colour == 'b' && amount > minBlue) {
                            minBlue = amount;
                        }
                    }
                }

                answerTwo += minRed * minGreen * minBlue;
            }
            #endregion

            Console.WriteLine($"DayTwo 1: {answerOne}");
            Console.WriteLine($"DayTwo 2: {answerTwo}");
        }
    }
}
