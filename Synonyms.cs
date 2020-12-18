using System;
using System.Text.Json;

namespace Csharp_api
{
    
    public abstract class Synonyms
    {
        public static string text = System.IO.File.ReadAllText(@"./data/synonyms.json");

        public static string getFullText() {

            JsonDocument json = JsonDocument.Parse(text);
            JsonElement root = json.RootElement;

            //String hmm = "";

            String hmm = root[949].GetProperty("word").ToString();

            return hmm;
        }
    }
}
