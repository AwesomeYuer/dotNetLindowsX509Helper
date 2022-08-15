namespace Microshaoft
{
    public static class ConsoleHelper
    {
        public static void HighlightWriteLine
                                        (
                                            string message
                                            , ConsoleColor foregroundColor = ConsoleColor.Red
                                            , params object?[]? args
                                        )
        {
            var orininalForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message, args);
            Console.ForegroundColor = orininalForegroundColor;
        }
    }
}
