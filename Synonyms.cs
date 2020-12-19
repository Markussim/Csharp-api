using System;
using System.Text.Json;

namespace Csharp_api
{

    public abstract class Synonyms
    {
        public static string text = System.IO.File.ReadAllText(@"./data/synonyms.json");

        public static JsonDocument json = JsonDocument.Parse(text);
        public static JsonElement root = json.RootElement;

        public static string getSynonym(String word)
        {
            int index = 0;

            for (int i = 0; i < root.GetArrayLength(); i++)
            {
                Console.WriteLine(i);
                if (root[i].GetProperty("word").ToString() == word)
                {
                    index = i;
                    break;
                }
            }

            String hmm = root[index].GetProperty("word").ToString();

            return hmm;
        }
    }
}
