using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NFA
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "ciag.txt";
            string stringForNFA = "";
            
            

            try
            {
                var stringFromFile = File.ReadAllLines(filePath);
                stringForNFA = string.Join(stringForNFA, stringFromFile);
            }
            catch(FileNotFoundException fileNotFoundException)
            {
                stringForNFA = "0123#01134#aabef#";
            }

            var arrayOfString = stringForNFA.Split('#');
            foreach (var slice in arrayOfString)
            {
                RemoveHash(slice);
               if(!string.IsNullOrWhiteSpace(slice))
                    Console.WriteLine("Ciąg: " + slice);
                Console.WriteLine();
                NFA nfa = new NFA();
                foreach (var character in slice)
                {
                    nfa.GetPath();
                    nfa.Automata(character);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Koniec");
            Console.ReadKey();
        }

        private static void RemoveHash(string slice)
        {
            if(!string.IsNullOrWhiteSpace(slice))
                slice.Remove(slice.Length - 1);
        }
    }
}
