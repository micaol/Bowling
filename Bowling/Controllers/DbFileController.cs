using System;
using System.IO;
using System.Threading;
using Bowling.Tools;

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
            catch(FileNotFoundException)
            {
                throw new ApplicationException(ErrorMessage.GAME_NOT_STARTED); 
            }
            catch(Exception)
            {
                // Retry strategy, up to ten times (0.5s) 
                Thread.Sleep(50); 
                if(tries > 0)
                {
                    return Load(tries - 1);  
                }
            }
            return "";
        }

        /// <summary>
        ///     Remove the file from the disk.
        /// </summary>
        /// <param name="tries"> Number of reamaining tries in case of failure. </param>
        public static void StartDB(int tries = 10)
        {
            try
            {
                File.Delete(filePath);
                File.AppendAllText(filePath,"");
            }
            catch(Exception)
            {
                // Retry strategy, up to ten times (0.5s) 
                Thread.Sleep(50); 
                if(tries > 0)
                {
                    StartDB(tries-1); 
                }
            }
        }
    }
}