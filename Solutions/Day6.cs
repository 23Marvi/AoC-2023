using System.Text.RegularExpressions;

namespace AoC_2023.Solutions {
    internal static class Day6 {
        private static readonly Regex numberRegex = new(@"\d+");

        internal static void SolveOne() {
            string[] input = FileReader.ReadFileLines(6);
            int answer = 0;

            int[] times = numberRegex.Matches(input[0]).Select(match => int.Parse(match.Value)).ToArray();
            int[] distances = numberRegex.Matches(input[1]).Select(match => int.Parse(match.Value)).ToArray();

            for (int gameId = 0; gameId < times.Length; gameId++) {
                int distanceToBeat = distances[gameId];
                int totalTime = times[gameId];
                int possibilities = 0;

                for (int time = 1; time < totalTime; time++) {
                    int timeToSail = totalTime - time;
                    int distance = timeToSail * time;
                    if (distance > distanceToBeat) possibilities++;
                }

                answer = (gameId == 0) ? possibilities : answer * possibilities;
            }

            Console.WriteLine($"Day6 1: {answer}");
        }

        internal static void SolveTwo() {
            string[] input = FileReader.ReadFileLines(6);
            long answer = 0;

            long totalTime = long.Parse(string.Join("", numberRegex.Matches(input[0])));
            long distanceToBeat = long.Parse(string.Join("", numberRegex.Matches(input[1])));

            for (int time = 1; time < totalTime; time++) {
                long timeToSail = totalTime - time;
                long distance = timeToSail * time;
                if (distance > distanceToBeat) answer++;
            }

            Console.WriteLine($"Day6 2: {answer}");
        }

        internal static void SolveBoth() {
            SolveOne();
            SolveTwo();
        }
    }
}
