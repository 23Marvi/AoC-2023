namespace AoC_2023 {
    internal static class FileReader {
        private const int _MinDay = 1;
        private const int _MaxDay = 25;

        public static string[] ReadFileLines(byte day) {
            string fullPath = ValidateDay(day);

            return File.ReadAllLines(fullPath);
        }

        public static string ReadFileAsString(byte day) {
            string fullPath = ValidateDay(day);

            return File.ReadAllText(fullPath);
        }

        private static string ValidateDay(byte day) {
            if (day < _MinDay || day > _MaxDay) {
                throw new ArgumentException($"Invalid day. Day must be between {_MinDay} and {_MaxDay}.");
            }

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Inputs/day{day}.txt");

            if (!File.Exists(fullPath)) {
                throw new FileNotFoundException($"File not found: {fullPath}");
            }

            return fullPath;
        }
    }
}