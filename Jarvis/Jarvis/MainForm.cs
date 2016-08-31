using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechProcessor;
using System.Speech.Recognition;
using Common;
using InputClasses;
using NNBuilder_Runable;
using Common.structs;
using Neurons;
using Graph_Database_Access;
using SQL_Database_Access;
using Common.DTO;
using CommandInterfaces;
using edu.stanford.nlp.tagger.maxent;
using java.util;
using edu.stanford.nlp.ling;
using java.io;
using System.Threading;
using Neo4jClient;
using Graph_Database_Access.BusinessObjects;

namespace Jarvis
{
    public partial class MainForm : Form
    {
        public IInput inPutLayer;
        public Matrix matrix;
        public SpeechProcessor.SpeechProcessor sp;
        public SerialStreamingInput ssI;
        public MainForm()
        {
            InitializeComponent();
           
        }

           
        private void btnStartSpeechProcessor_Click(object sender, EventArgs e)
        {
            sp = new SpeechProcessor.SpeechProcessor();
            sp.InitializeProcessor();
            sp.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);

        }
        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text.ToString().ToLower();
           
                CommandProcessor cp = new CommandProcessor();
                InputLogic il = new InputLogic();
                PhraseLogic pl = new PhraseLogic();
                InsertMissingWordData(result);

                pl.InsertPhraseStoredProc(result);
               // List<NodeReferenceStats> phRefs = pl.InsertPhraseForStatAnalysis(e.Result.Text.ToString());
               // string results = il.updateStatsFireNodes(phRefs);
               // cp.ExecuteCommand(results);


                

            //    matrix.SpeechInput(e.Result.Text.ToString());
            //}

        }

        private List<List<WordDTO>> InsertMissingWordData(string result)
        {
            List<List<WordDTO>> results = new List<List<WordDTO>>();
            WordWebLogic wwl = new WordWebLogic();
            WordLogic wl = new WordLogic();
            string[] words = result.Split(' ');
            foreach (string word in words)
            {
               var wordData = wwl.GetWord(word);
               
                if (wordData != null)
                {
                    foreach (var wd in wordData)
                    {
                       wd.ID = wl.InsertWord(wd);

                    }
                }
                results.Add(wordData);
            }
            return results;
        }

        private void btnBuildNetwork_Click(object sender, EventArgs e)
        {
            Int16 x = 500, y = 500, z = 500, t = 5;
          //  matrix = new Network.Matrix(y, x, z, t);
          //  Utilities ut = new Utilities();
            BuildMatrix bm = new BuildMatrix();
            bm.Build_New_Matrix(y, x, z, t, 8,2);
            
         //   inPutLayer = new SerialStreamingInput(ref matrix);

            List<coordinates[]> inputBytes = bm.inputBytes;
            List<coordinates[]> outputBytes = bm.outputBytes;
            matrix = bm.matrix;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdDictionaryFile.ShowDialog();
            if(result== DialogResult.OK)
            {
                // GraphDB gb = new GraphDB();
                // gb.CreateIndexes();
                int x = 0;
                List<Thread> activeThreads = new List<Thread>();
                while (x < ofdDictionaryFile.FileNames.Length)
                {
                    while (activeThreads.Count < 7)
                    {
                        // gb.LoadDictionaryFile(filename);
                        //Load Brown files
                        BrownTrainingData btd = new BrownTrainingData();
                        btd.filename = ofdDictionaryFile.FileNames[x];

                        x++;
                        Thread oThread = new Thread(new ThreadStart(btd.parseBrownText));

                        // Start the thread
                        oThread.Start();

                        activeThreads.Add(oThread);
                        for (int i = 0; i < activeThreads.Count; i++)
                        {
                            if (!activeThreads[i].IsAlive)
                            {
                                activeThreads[i].Join();
                                activeThreads[i].Abort();
                                activeThreads.RemoveAt(i);
                                i--;
                            }
                        }


                    }

                    Thread.Sleep(10000);
                    for (int i = 0; i < activeThreads.Count; i++)
                    {
                        if (!activeThreads[i].IsAlive)
                        {
                            activeThreads[i].Join();
                            activeThreads[i].Abort();
                            activeThreads.RemoveAt(i);
                            i--;
                        }
                    }
                }
                foreach (string filename in ofdDictionaryFile.FileNames)
                {
                  

                }
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertMissingWordData(txtToSubmit.Text);
            CommandProcessor cp = new CommandProcessor();
            InputLogic il = new InputLogic();
            PhraseLogic pl = new PhraseLogic();
           

            pl.InsertPhraseStoredProc(txtToSubmit.Text);
        }

        private void btnInserPOSandWords_Click(object sender, EventArgs e)
        {
            GraphDB gb = new GraphDB();
            PartOfSpeechLogic posl = new PartOfSpeechLogic();
            WordLogic wl = new WordLogic();
            List<PosDTO> poss = new List<PosDTO>();
            Dictionary<int, NodeReference<PartOfSpeech>> posDictionary = new Dictionary<int, NodeReference<PartOfSpeech>>();
            List< NodeReference<Graph_Database_Access.BusinessObjects.Word>> wordDictionary = new List<NodeReference<Graph_Database_Access.BusinessObjects.Word>>();
            //poss = posl.GetPOSAndIds();
            //foreach (var pos in poss)
            //{
              
            //    gb.InsertPOS(pos.pos, pos.ID);
            //}

            List<WordDTO> wordList = wl.GetWordsAndIds();
            foreach(var word in wordList)
            {
             
        
                gb.Insert_Word_Node(word.word, word.ID);
                var posR = gb.getPartOfspeechByID(word.partOfSpeechID);
                var mwR = gb.getWordByID(word.ID);
                if (posR != null && mwR != null)
                {
                    gb.createWordPOSRelationship(posR, mwR);
                }
            }
           

         



        }
    }
}
