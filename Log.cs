namespace AoC_2023 {
    internal static class Log {
        private static ConsoleColor _defaultColour = ConsoleColor.White;

        internal static void WriteLine() => WriteLine("", _defaultColour);
        internal static void WriteLine(char? value) => WriteLine(value, _defaultColour);
        internal static void WriteLine(char? value, ConsoleColor? colour) => WriteLine(value.ToString(), colour);
        internal static void WriteLine(string? value) => WriteLine(value, _defaultColour);

        internal static void WriteLine(string? value, ConsoleColor? colour) {
            Console.ForegroundColor = colour ?? _defaultColour;
            Console.WriteLine(value);
            Console.ForegroundColor = _defaultColour;
        }

        internal static void Write() => Write("", _defaultColour);
        internal static void Write(char? value) => Write(value, _defaultColour);
        internal static void Write(char? value, ConsoleColor? colour) => Write(value.ToString(), colour);
        internal static void Write(string? value) => Write(value, _defaultColour);

        internal static void Write(string? value, ConsoleColor? colour) {
            Console.ForegroundColor = colour ?? _defaultColour;
            Console.Write(value);
            Console.ForegroundColor = _defaultColour;
        }
    }
}
