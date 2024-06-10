namespace Match3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var form = new Form1();
            var game = new Match3.components.Match3(form,new Size(4,4));
            ApplicationConfiguration.Initialize();
            Application.Run(form);
        }
    }
}