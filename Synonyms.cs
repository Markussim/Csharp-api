using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Collections;
using System.Globalization;

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

            /*foreach (var item in otherJson.ToArray())
            {
                System.Console.WriteLine(item.word);
            }*/


            if (word.Length > 1)
            {
                WordClass word2 = new WordClass();

                word2.word = word;

                int index = otherJson.BinarySearch(word2);

                if (index > 0 && index < otherJson.Count)
                {
                    WordClass foundWord = otherJson[index];

                    if (foundWord.synonyms.Count > 0) output = foundWord.synonyms[rnd.Next(0, foundWord.synonyms.Count - 1)];

                    //output = "Hmm";
                }


            }




            if (output.Length == 0)
            {
                //System.Console.WriteLine("Fail");
                output = word;
            }

            return output;
        }

        public static void sort()
        {
            otherJson.Sort();
        }
    }

    public class WordClass : IComparable<WordClass>
    {
        public String word { get; set; }

        public List<String> synonyms { get; set; }

        public int CompareTo(WordClass other)
        {

            /*if (String.Compare(other.word, this.word) > 0) return -1;
            else if (this.word.Equals(other.word)) return 0;
            else return 1;*/

            return this.word.CompareTo(other.word);
        }
    }
}
