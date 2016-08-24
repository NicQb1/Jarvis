using Common.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Database_Access
{
    public class BrownTrainingData
    {
        public void parseBrownText(string filename)
        {
            string xmlString;
            StringBuilder output = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                   
                   
                        xmlString = sr.ReadToEnd();
                    string[] words = xmlString.Split(' ');
                    foreach (var wordPOS in words)
                    {
                        InsertWordAndPartOfSpeech(wordPOS);
                      }
                    
                }

            }
            catch (Exception ex)
            {
                return;
            }
            return;
        }

        private void InsertWordAndPartOfSpeech(string wordPOS)
        {
            string[] wordPair = wordPOS.Trim().Split('/');
            PartOfSpeechLogic posl = new PartOfSpeechLogic();
            int posId = posl.GetPartOfSpeech(wordPair[1].Trim());

            WordLogic wl = new WordLogic();

            wl.InsertWordAndPOS(wordPair[0].Trim(), posId);

        }
    }
}
