namespace Core.Logs
{
    public class Log
    {
        private static readonly MainLog _main = new MainLog();
        private static readonly UILog _ui = new UILog();
        public static MainLog Main => _main;
        public static MainLog Current => _main;
        public static UILog UI => _ui;
    }
}
