using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PhantomComic
{
    static class Program
    {
        // Imports
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();

        // Entry Point
        [STAThread]
        static void Main(string[] args)
        {
            // Setup Console
            SetWindowPos(GetConsoleWindow(), 0, 0, 0/*((Screen.PrimaryScreen.Bounds.Height / 2) - 250)*/, 0, 0, 0x0001);

            // Format Comics
            string path = "data\\";
            if (Directory.Exists(path))
            {
                string[] comics = Directory.GetDirectories(path);
                foreach (string comic in comics)
                {
                    Print("Formatting " + comic.Replace(path, "") + "..\n");
                    if (!File.Exists(comic + "\\banner.jpg"))
                        File.Move(comic + "\\banner", comic + "\\banner.jpg");
                    if (!File.Exists(comic + "\\detail.txt"))
                        File.Move(comic + "\\detail", comic + "\\detail.txt");
                    if (Directory.Exists(comic + "\\comic"))
                    {
                        string[] chapters = Directory.GetDirectories(comic + "\\comic");
                        foreach (string chapter in chapters)
                        {
                            string[] pages = Directory.GetFiles(chapter);
                            foreach (string page in pages)
                                if (!page.EndsWith(".jpg"))
                                    File.Move(page, page + ".jpg");
                        }
                    }
                }
                Print("\nFormatting complete. Forms will now initiate.");
                Thread.Sleep(2000);
            }

            // Initialize Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static void Print(string text)
        {
            Console.Write(text);
        }
    }
}