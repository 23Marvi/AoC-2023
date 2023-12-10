namespace AoC_2023.Solutions {
    internal static class Day4 {
        internal static void SolveOne() {
            string[] input = FileReader.ReadFileLines(4);
            int answer = 0;

            foreach (string card in input) {
                string[] splitCard = card.Split("|");
                int[] winningNumbers = splitCard[0].Split(": ")[1].Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray().Select(s => int.Parse(s)).ToArray();
                int[] myNumbers = splitCard[1].Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray().Select(s => int.Parse(s)).ToArray();
                int numberOfMatches = myNumbers.Intersect(winningNumbers).Count();

                if (numberOfMatches <= 1) answer += numberOfMatches;
                else answer += (int)Math.Pow(2, numberOfMatches - 1);
            }

            Console.WriteLine($"Day4 1: {answer}");
        }

        internal static void SolveTwo() {
            List<string> input = FileReader.ReadFileLines(4).ToList();
            int[] numberOfCards = Enumerable.Repeat(1, input.Count).ToArray();
            int answer = input.Count;

            for (int i = 0; i < input.Count; i++) {
                string[] splitCard = input[i].Split("|");
                int[] winningNumbers = splitCard[0].Split(": ")[1].Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray().Select(s => int.Parse(s)).ToArray();
                int[] myNumbers = splitCard[1].Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray().Select(s => int.Parse(s)).ToArray();
                int numberOfMatches = myNumbers.Intersect(winningNumbers).Count();

                for (int j = 0; j < numberOfMatches; j++) {
                    numberOfCards[i + 1 + j] += 1 * numberOfCards[i];
                }
            }

            answer = numberOfCards.Sum();

            Console.WriteLine($"Day4 2: {answer}");
        }

        internal static void SolveBoth() {
            SolveOne();
            SolveTwo();
        }
    }
}
