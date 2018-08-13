using System;
using System.IO;

namespace Bowling.Controllers
{
    /// <summary>
    ///     Read, Write and delete files.
    /// </summary>
    public class DbFileController
    {
        private string dataLoaded; 
        private string filePath = "BowlingFileDB.txt"; 
        
        /// <summary>
        ///     Save a string in a file.
        /// </summary>
        /// <param name="data"> Data to be written into the file. </param>
        public void Save(string data)
        {
            File.AppendAllText(this.filePath, data + " ");
        }

        /// <summary>
        ///     Read the file from the disk.
        /// </summary>
        /// <returns> Return the content of the file. </returns>
        public string Load()
        {
            return File.ReadAllText(this.filePath);
        }

        /// <summary>
        ///     Remove the file from the disk.
        /// </summary>
        public void ClearDB()
        {
            File.Delete(this.filePath);
        }
    }
}