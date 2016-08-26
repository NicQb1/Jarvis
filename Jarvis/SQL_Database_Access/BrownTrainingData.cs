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
        public string filename;

        public void parseBrownText()
        {
            string xmlString;
            StringBuilder output = new StringBuilder();

          
                using (StreamReader sr = new StreamReader(filename))
                {
                try
                {
                    PartOfSpeechLogic posL = new PartOfSpeechLogic();
                    TupleLogic tl = new TupleLogic();
                  
                    while (!sr.EndOfStream)
                    {
                        List<int> wordIds = new List<int>();
                        List<int> POSwordIds = new List<int>();
                        List<int> tuple1Ids = new List<int>();
                        List<int> POStuple1Ids = new List<int>();
                        List<int> tuple2Ids = new List<int>();
                        List<int> POStuple2Ids = new List<int>();
                        List<int> tuple3Ids = new List<int>();
                        List<int> POStuple3Ids = new List<int>();
                        List<int> tuple4Ids = new List<int>();
                        List<int> POStuple4Ids = new List<int>();
                        xmlString = sr.ReadLine();
                        string[] words = xmlString.Split(' ');
                        foreach (var wordPOS in words)
                        {
                            string[] wordPair = wordPOS.Trim().Split('/');
                            PartOfSpeechLogic posl = new PartOfSpeechLogic();
                            
                            if (wordPair.Length == 2)
                            {
                                int posId = posl.GetPartOfSpeech(wordPair[1].Trim());

                                POSwordIds.Add(posId);
                                wordIds.Add(InsertWordAndPartOfSpeech(wordPair[0].Trim(), posId));
                            }
                        }
                        for(int i = 0; i < wordIds.Count-1; i++)
                        {
                            tuple1Ids.Add( tl.InsertTuple(wordIds[i], wordIds[i + 1]));
                            POStuple1Ids.Add(tl.InsertTupleByStoredProc("sp_insertPOSTupleN2",POSwordIds[i], POSwordIds[i + 1]));

                        }
                        for (int i = 0; i < tuple1Ids.Count - 1; i++)
                        {
                            tuple2Ids.Add(tl.InsertTupleByStoredProc("sp_insertTupleN2x2",tuple1Ids[i], tuple1Ids[i + 1]));
                            POStuple2Ids.Add(tl.InsertTupleByStoredProc("sp_insertPOSTupleN2x2", POStuple1Ids[i], POStuple1Ids[i + 1]));

                        }
                        for (int i = 0; i < tuple2Ids.Count - 1; i++)
                        {
                            tuple3Ids.Add(tl.InsertTupleByStoredProc("sp_insertTupleN2x3", tuple2Ids[i], tuple2Ids[i + 1]));
                            POStuple3Ids.Add(tl.InsertTupleByStoredProc("sp_insertPOSTupleN2x3", POStuple2Ids[i], POStuple2Ids[i + 1]));

                        }
                        for (int i = 0; i < tuple3Ids.Count - 1; i++)
                        {
                          tl.InsertTupleByStoredProc("sp_insertTupleN2x4", tuple3Ids[i], tuple3Ids[i + 1]);
                          tl.InsertTupleByStoredProc("sp_insertPOSTupleN2x4", POStuple3Ids[i], POStuple3Ids[i + 1]);

                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }

            
            return;
        }

        private int InsertWordAndPartOfSpeech(string wordPOS, int posId)
        {
          
            WordLogic wl = new WordLogic();

         return   wl.InsertWordAndPOS(wordPOS.Trim(), posId);

        }
    }
}
