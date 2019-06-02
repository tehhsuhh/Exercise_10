using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//This program was created by Tessa Biava
namespace Exercise_10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader inputFile = new StreamReader("input.txt");

                string[] inputString = inputFile.ReadToEnd().Split();
                int tOrECount = 0;

                //cycle through the array of strings.
                foreach (string subString in inputString)
                {
                    //check end of string for punctuation
                    if (char.IsPunctuation(subString, subString.Length - 1))
                    {
                        //create a new string so we can remove the punctuation at the end of the string.
                        string modifiedString = subString.Remove(subString.Length - 1);

                        //allow for further removal of additional punctuation, should there be multiples.
                        while (char.IsPunctuation(modifiedString, modifiedString.Length - 1))
                        {
                            modifiedString = modifiedString.Remove(modifiedString.Length - 1);
                        }

                        //check the last letter.
                        if (modifiedString.EndsWith("t") || modifiedString.EndsWith("e") ||
                            modifiedString.EndsWith("T") || modifiedString.EndsWith("E"))
                        {
                            tOrECount++;
                        }
                    }
                    else //no punctuation
                    {
                        //compare
                        if (subString.EndsWith("t") || subString.EndsWith("e") ||
                            subString.EndsWith("T") || subString.EndsWith("E"))
                        {
                            tOrECount++;
                        }
                    }
                }

                Console.WriteLine("There are " + tOrECount + " words that end in 't' or 'e'");
                inputFile.Close();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
