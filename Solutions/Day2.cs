namespace AoC_2023.Solutions {
    internal class DayTwo {
        internal static void SolveOne() {
            string[] input = FileReader.ReadFileLines(2);
            int answer = 0;

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
                    answer += int.Parse(gameId);
                }
            }

            Console.WriteLine($"DayTwo 1: {answer}");
        }

        internal static void SolveTwo() {
            string[] input = FileReader.ReadFileLines(2);
            int answer = 0;

            foreach (string game in input) {
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

                answer += minRed * minGreen * minBlue;
            }

            Console.WriteLine($"DayTwo 2: {answer}");
        }

        internal static void SolveBoth() {
            SolveOne();
            SolveTwo();
        }
    }
}
