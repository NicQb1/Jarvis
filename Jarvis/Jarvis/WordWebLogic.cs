using Common.DTO;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
    public class WordWebLogic
    {
        public string Word;

        public List<WordDTO> GetWord(string word)
        {
            try
            {
                Word = word;
                string sURL;
                sURL = "http://www.thesaurus.com/browse/" + word;

                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);



                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string sLine = objReader.ReadToEnd();

                return ParseThesaurusPage(sLine);
            }catch(Exception ex)
            {
                return null;
            }
            
        }

        private List<WordDTO> ParseThesaurusPage(string sLine)
        {
            List<WordDTO> results = new List<WordDTO>();
            int i = 0;
            List<string> synonymGroups = new List<string>();
            int thisOne = 0;
            while (sLine.IndexOf("<div id=\"synonyms-" + i.ToString()) > 0)
            {
                thisOne = sLine.IndexOf("<div id=\"synonyms-" + i.ToString());
                int next = sLine.IndexOf("</section>", thisOne);
                string temp = sLine.Substring(thisOne, "</section>".Length + next - thisOne);
                synonymGroups.Add(temp);
                i++;
            }

            foreach (var syng in synonymGroups)
            {
                WordDTO tmp = parseSynonymSection(syng);
                tmp.word = Word;
                results.Add(tmp);
            }

            return results;

        }
        
        private WordDTO parseSynonymSection(string html)
        {
            WordDTO results = new WordDTO();
            string temp = html;
            int locationA = 0;
            int locationB = 0;
            locationA = temp.IndexOf("<em class");
            locationA = temp.IndexOf(">", locationA);
            locationB = temp.IndexOf("<", locationA);
            string pos = temp.Substring(locationA +1, locationB - locationA -1);
            if (pos == "adj")
                pos = "Adjective";
            if (pos == "conj")
                pos = "Conjunction";
            results.partOfSpeech = pos;
            results.synonyms = getSynonyms(temp);
            results.antonyms = getListOfAntonyms(temp);


          
            return results;
        }

        private List<AntonymDTO> getListOfAntonyms(string temp)
        {
            List<AntonymDTO> results = new List<AntonymDTO>();
            int locationA = 0;
            int locationB = 0;
            string ulSubstring = string.Empty;

            locationA = temp.IndexOf("<ul>");
            locationB = temp.IndexOf("</div>", locationA);
            ulSubstring = temp.Substring(locationB);

            while (ulSubstring.Contains("data-complexity"))
            {
                locationA = ulSubstring.IndexOf("<li>");
                locationB = ulSubstring.IndexOf("</li>");
                string li = ulSubstring.Substring(locationA, locationB + 5 - locationA);
                ulSubstring = ulSubstring.Substring(locationB + 5);
                locationA = li.IndexOf("data-complexity=");
                locationA = locationA + "data-complexity=".Length;
                locationA = li.IndexOf('"', locationA);
                locationB = li.IndexOf('"', locationA + 1);
                string complexity = li.Substring(locationA + 1, locationB - locationA - 1);
                locationA = li.IndexOf("<span class=\"text\">");
                locationA = locationA + "<span class=\"text\">".Length;
                locationB = li.IndexOf("<", locationA);
                string ant = li.Substring(locationA, locationB - locationA);
                AntonymDTO tmp = new AntonymDTO();
                tmp.complexity = int.Parse(complexity);
                tmp.word = ant;
                results.Add(tmp);
            }

            return results;
        }

        private List<SynonymDTO> getSynonyms(string temp)
        {
            List<SynonymDTO> results = new List<SynonymDTO>();
            int locationA = 0;
            int locationB = 0;
            string ulSubstring = string.Empty;

                locationA = temp.IndexOf("<ul>");
                locationB = temp.IndexOf("</div>", locationA);
               ulSubstring =  temp.Substring(locationA, locationB - locationA);
            while(ulSubstring.Contains("data-complexity"))
            {
                locationA = ulSubstring.IndexOf("<li>");
                locationB = ulSubstring.IndexOf("</li>");
                string li = ulSubstring.Substring(locationA, locationB + 5 - locationA);
                ulSubstring = ulSubstring.Substring(locationB + 5);
                locationA = li.IndexOf("data-complexity=");
                locationA = locationA + "data-complexity=".Length;
                locationA = li.IndexOf('"', locationA);
                locationB = li.IndexOf('"', locationA + 1);
                string complexity = li.Substring(locationA + 1, locationB - locationA - 1);
                locationA = li.IndexOf("<span class=\"text\">");
                locationA = locationA + "<span class=\"text\">".Length;
                locationB = li.IndexOf("<", locationA );
                string syn = li.Substring(locationA, locationB - locationA);
                SynonymDTO tmp = new SynonymDTO();
                tmp.complexity = int.Parse(complexity);
                tmp.word = syn;
                results.Add(tmp);
            }

            return results;
        }
    }
}
