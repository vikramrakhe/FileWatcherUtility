using System;
using System.IO;
using System.Security.Permissions;

namespace FileWatcherUtility
{
    public class Watcher
    {
        public static void Main()
        {
            Run();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            //string[] args = System.Environment.GetCommandLineArgs();
            var args = new[] { "Watcher.exe", "D:\\Vikram.Office\\GitHubPersonal\\SampleDirectoryForFileWatcher" };

            // If a directory is not specified, exit program.
            if (args.Length != 2)
            {
                // Display the proper way to call the program.
                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = args[1];
            /* Watch for changes in LastWrite times */
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            
            // Only watch xml files.
            watcher.Filter = "*.xml";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            
            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q')
            {
            }
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed.
            Console.WriteLine("File: " + e.Name + " " + e.ChangeType);
        }
    }
}