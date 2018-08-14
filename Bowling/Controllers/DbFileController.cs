using System;
using System.IO;
using System.Threading;

namespace Bowling.Controllers
{
    /// <summary>
    ///     Read, Write and delete files.
    /// </summary>
    public static class DbFileController
    {
        /// <summary>
        ///     File which stores the data.
        /// </summary>
        public const string  filePath = "BowlingFileDB.txt"; 
        
        /// <summary>
        ///     Save a string in a file.
        /// </summary>
        /// <param name="data"> Data to be written into the file. </param>
        /// <param name="tries"> Number of reamaining tries in case of failure. </param>

        public static void Save(int data, int tries = 10)
        {
            try
            {
                File.AppendAllText(filePath, data + " ");
            }
            catch(Exception)
            {
                // Retry strategy, up to ten times (0.5s) 
                Thread.Sleep(50); 
                if(tries > 0)
                {
                    Save(data, tries - 1);  
                }
                else
                {
                    Console.Out.WriteLine("FAIL to save data to file: " + data);
                }
            }
        }

        /// <summary>
        ///     Read the file from the disk.
        /// </summary>
        /// <param name="tries"> Number of reamaining tries in case of failure. </param>
        /// <returns> Return the content of the file. </returns>
        public static string Load(int tries = 10)
        {

            try
            {
                return File.ReadAllText(filePath);
            }
            catch(Exception)
            {
                // Retry strategy, up to ten times (0.5s) 
                Thread.Sleep(50); 
                if(tries > 0)
                {
                    return Load(tries - 1);  
                }
                else
                {
                    Console.Out.WriteLine("FAIL to load data from file. ");
                }
            }
            return "";
        }

        /// <summary>
        ///     Remove the file from the disk.
        /// </summary>
        /// <param name="tries"> Number of reamaining tries in case of failure. </param>
        public static void ClearDB(int tries = 10)
        {
            try
            {
                File.Delete(filePath);
            }
            catch(Exception)
            {
                // Retry strategy, up to ten times (0.5s) 
                Thread.Sleep(50); 
                if(tries > 0)
                {
                    ClearDB(tries-1); 
                }
                else
                {
                    Console.Out.WriteLine("FAIL to clear file from disk. ");
                }
            }
        }
    }
}