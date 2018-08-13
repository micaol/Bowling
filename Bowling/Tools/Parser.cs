using System;
using System.Collections.Generic;

namespace Bowling.Tools
{
    /// <summary>
    ///     Static parsing tools. 
    /// </summary>
    public static class Parser
    {   

        /// <summary>
        ///     Convert a string like "2 3 10 2" to a list of integer {2,3,10,2}.
        /// </summary>
        /// <param name="s">String which contains a list of integer seperated by a coma. </param>
        /// <returns> A list of integer. </returns>
        public static List<int> GetIntegers(string s)
        {
            var integerList = new List<int>(); 
            string[] list = s.Split(' '); 
            foreach(string number in list)
            {
                int i; 
                bool isParsed = int.TryParse(number,out i); 
                if(isParsed)
                {   
                    integerList.Add(i); 
                }    
            }
            return integerList; 
        }
    }
}