namespace Microshaoft
{
    public static class ConsoleHelper
    {
        public static void HighlightWriteLine
                                        (
                                            string message
                                            , ConsoleColor foregroundColor = ConsoleColor.Red
                                            , params object?[]? arg
                                        )
        {
            var orininalForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message, arg);
            Console.ForegroundColor = orininalForegroundColor;
        }
    }
}
