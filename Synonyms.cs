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
                foreach (var item in otherJson)
                {
                    if (item.word == word)
                    {
                        try
                        {
                            output = item.synonyms[rnd.Next(0, item.synonyms.ToArray().Length)];
                        }
                        catch { }

                        break;
                    }
                }
            }



            if (output.Length == 0)
            {
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
