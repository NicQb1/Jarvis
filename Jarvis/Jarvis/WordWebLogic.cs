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

        public List<WordDTO> GetWord(string word)
        {

            string sURL;
            sURL = "http://www.thesaurus.com/browse/" + word;

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);



            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sLine = objReader.ReadToEnd();

            return ParseThesaurusPage(sLine);
        }

        private List<WordDTO> ParseThesaurusPage(string sLine)
        {
            List<WordDTO> results = new List<WordDTO>();
            //int i = sLine.IndexOf("<div id=\"content\" class=\"direct\">");
            // int j = sLine.IndexOf( "<div id=\"right - sidebar\">", i);
            // sLine = sLine.Substring(i, j - i);
            int i = 0;
            List<string> synonymGroups = new List<string>();
            int thisOne = 0;
            while (sLine.IndexOf("<div id=\"synonyms -" + i.ToString()) > 0)
            {
                thisOne = sLine.IndexOf("<div id=\"synonyms -" + i.ToString());
                int next = sLine.IndexOf("</ section >", thisOne);
                string temp = sLine.Substring(thisOne, next - thisOne);
                synonymGroups.Add(temp);
                i++;
            }

            foreach (var syng in synonymGroups)
            {

            }

            return results;

        }

        private WordDTO parseSynonymsHTML(HtmlNode hn, int level)
        {
            WordDTO result = new WordDTO();
            result.synonyms = new List<SynonymDTO>();
            result.antonyms = new List<AntonymDTO>();
            var tn = hn.ChildNodes[3];
            var pos = tn.ChildNodes[1].ChildNodes[1].ChildNodes[13].ChildNodes[7].ChildNodes[1].ChildNodes[1].InnerHtml;
            if (pos == "adj")
                pos = "Adjective";
            if (pos == "conj")
                pos = "Conjunction";


            var sn = tn.ChildNodes[1].ChildNodes[1].ChildNodes[13].ChildNodes[7].ChildNodes[3].ChildNodes[5];
            result.partOfSpeech = pos;
            string[] synonyms = tn.ChildNodes[1].ChildNodes[1].ChildNodes[13].ChildNodes[7].ChildNodes[3].ChildNodes[3].ChildNodes[3].InnerText.Split(';');
            foreach (string syn in synonyms)
            {
                SynonymDTO tmp = new SynonymDTO();
                tmp.complexity = 0;
                tmp.word = syn;
                result.synonyms.Add(tmp);
            }
            result.synonyms = getListOfSynonyms(sn, level);
            result.antonyms = getListOfAntonyms(tn, level);
            return result;

        }

        private List<AntonymDTO> getListOfAntonyms(HtmlNode tn, int level)
        {
            List<AntonymDTO> results = new List<AntonymDTO>();
            var sn = tn.SelectNodes("//*[@id=\"synonyms -" + level.ToString() + "\"]/section/div[2]/ul");
            foreach (var n in sn)
            {
                foreach (var m in n.ChildNodes)
                {
                    //each LI in UL
                    var attributes = m.Attributes;

                    AntonymDTO tmp = new AntonymDTO();
                    tmp.complexity = int.Parse(attributes["data-complexity"].ToString());
                    tmp.word = m.ChildNodes[0].InnerText; ;
                    results.Add(tmp);
                }
            }
            return results;
        }

        private List<SynonymDTO> getListOfSynonyms(HtmlNode tn, int level)
        {
            List<SynonymDTO> results = new List<SynonymDTO>();
            var rn = tn.SelectNodes("//ul/");
            foreach (var n in rn)
            {
                foreach (var m in n.ChildNodes)
                {
                    //each LI in UL
                    var attributes = m.Attributes;

                    SynonymDTO tmp = new SynonymDTO();
                    tmp.complexity = int.Parse(attributes["data-complexity"].ToString());
                    tmp.word = m.ChildNodes[0].InnerText; ;
                    results.Add(tmp);
                }
            }

            return results;
        }
    }
}
