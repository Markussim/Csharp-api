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

        public static string getSynonym(String word)
        {

            string output = "";

            foreach (var item in otherJson)
            {
                if(item.word == word) {
                    System.Console.WriteLine(item.synonyms[0]);
                    output = item.synonyms[0];
                }
            }

            return output;
        }
    }

    public class WordClass
    {
        public String word { get; set; }

        public List<String> synonyms { get; set;}
    }
}
