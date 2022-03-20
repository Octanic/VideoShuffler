using System;
using System.Windows.Forms;

namespace VideoShuffler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string context = System.Environment.MachineName;
            bool autoMode = false;

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-auto")
                    {
                        autoMode = true;
                    }
                    else
                    {
                        context = args[i];

                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            const EntryHandler.EntryHandlerFactory.EntryHandlerType entryHandlerType = EntryHandler.EntryHandlerFactory.EntryHandlerType.Registry;

            Application.Run(new FrmMain(context, autoMode, entryHandlerType));
        }
    }
}
