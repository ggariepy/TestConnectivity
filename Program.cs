using System;
using System.IO;
using System.Collections.Generic;
namespace TestConnectivity
{
    class Program
    {

        static void Main(string[] args)
        {
            int reps;
            string location;
            string filter;

            Dictionary<string, string> files = new Dictionary<string, string>(); 

            if (args.Length == 0)
                 reps = 50000;
           else
                int.TryParse(args[0], out reps);

            if (args.Length < 2)
                location = @"\\MPDBC1VS\TG\Individual\TD";
            else
                location = args[1];

            if (args.Length < 3)
                filter = @"*.TD*";
            else
                filter = args[2];

            Console.WriteLine($"Testing connectivity to {location} {reps} times for files of type [{filter}]");

            FileInfo[] FileList = new FileInfo[1000];
            int i = 0;
            try
            {
                for (i = 0; i < reps; i++)
                {
                    DirectoryInfo di = new DirectoryInfo(location);
                    FileList = di.GetFiles(filter);
                    foreach(FileInfo fn in FileList)
                    {
                        if (!files.ContainsKey(fn.FullName))
                            files.Add(fn.FullName, fn.FullName);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed after iteration #{i} with error {ex.Message}");
                Environment.Exit(-1);
            }


            Console.WriteLine($"Finished {i} tests for files of type [{filter}]");
            if (files.Keys.Count > 0)
                foreach (string key in files.Keys)
                    Console.WriteLine($"Found file: {key}");
            else
                Console.WriteLine($"Did not find any [{filter}] files at this time.");

            Environment.Exit(0);

        }
    }
}
