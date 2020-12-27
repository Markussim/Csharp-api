using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csharp_api
{

    public abstract class Synonyms
    {
        public static string text = System.IO.File.ReadAllText(@"./data/synonyms.json");
        public static List<WordClass> otherJson = System.Text.Json.JsonSerializer.Deserialize<List<WordClass>>(text);
        public static Random rnd = new Random();

        public static string getSynonym(String word)
        {
            string output = "";

            if (word.Length > 1)
            {
                int minNum = 0;
                int maxNum = otherJson.Count - 1;

                while (minNum <= maxNum && maxNum <= otherJson.Count)
                {
                    int mid = (minNum + maxNum) / 2;
                    if (word == otherJson[mid].word)
                    {
                        System.Console.WriteLine("Success");
                        output = otherJson[mid].synonyms[rnd.Next(0, otherJson[mid].synonyms.ToArray().Length)];
                        break;
                    }
                    else if (String.Compare(word.ToUpper(), otherJson[mid].word.ToUpper()) < 0)
                    {
                        System.Console.WriteLine("Too high");
                        maxNum = mid - 1;
                    }
                    else
                    {
                        System.Console.WriteLine("Too low");
                        minNum = mid + 1;
                    }
                }
            }


            if (output.Length == 0)
            {
                System.Console.WriteLine("Fail");
                output = word;
            }

            return output;
        }
    }

    public class WordClass
    {
        public String word { get; set; }

        public List<String> synonyms { get; set; }
    }
}
