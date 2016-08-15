using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using Neurons;
using Net.Graph;
using Net.Graph.Neo4JD;
using Neo4jClient;
using Graph_Database_Access.Relationships;
using Graph_Database_Access.BusinessObjects;
using Graph_Database_Access.AccessClasses;
using System.Xml;
using System.IO;


namespace Graph_Database_Access
{
    public class GraphDB
    {
       
        public void CreateIndexes()
        {
            createIndexOnWord();
        }
        private void createIndexOnWord()
        {
            WordAccess wa = new WordAccess();
            wa.client.Cypher
  .Create("INDEX ON :Word(word)")
  .ExecuteWithoutResults();
        }

        private Node<Word> InsertWordByStringGetNode(string word)
        {
            var myword = new Word();
            myword.currentExitation = 0;
            myword.firePoint = 5;
            myword.lastFired = DateTime.Now;
            myword.word = word;
            WordAccess wa = new WordAccess();
            List<Word> wordList = wa.getMatchingNodes(myword);
            if (wordList == null)
            {
                var newword = wa.CreateNode(myword, new Dictionary<string, object>());
                Node<Word> nr = wa.InsertNode(myword, new Dictionary<string, object>());
                return nr;
            }
           
                return null ;
            

           
        }

        private NodeReference<Word> InsertWordGetNodeReferenceByString(string word)
        {
            var myword = new Word();
            myword.currentExitation = 0;
            myword.firePoint = 5;
            myword.lastFired = DateTime.Now;
            myword.word = word;
            WordAccess wa = new WordAccess();
            List<Word> wordList = wa.getMatchingNodes(myword);
            if (wordList == null)
            {
                NodeReference<Word> nr = wa.InsertNode2(myword, new Dictionary<string, object>());
                return nr;
            }

            return null;



        }

        private Node<Word> InsertWordByWordGetNode(Word myword)
        {
           
            WordAccess wa = new WordAccess();
            List<Word> wordList = wa.getMatchingNodes(myword);
            if (wordList == null)
            {

                var newword = wa.CreateNode(myword, new Dictionary<string, object>());
                Node<Word> nr = wa.InsertNode(myword, new Dictionary<string, object>());
                return nr;
            }

            return null;

        }
        private NodeReference<Word> InsertWordByWordGetNodeReference(Word myword)
        {

            WordAccess wa = new WordAccess();
            List<Word> wordList = wa.getMatchingNodes(myword);
            if (wordList == null)
            {

                var newword = wa.CreateNode(myword, new Dictionary<string, object>());
                var nr = wa.InsertNode2(myword, new Dictionary<string, object>());
                return nr;
            }

            return null;

        }

        public Node<Phrase> InsertPhrase(string phrase)
        {
            var phr = new Phrase();
            phr.phrase = phrase;
            PhraseAccess pa = new PhraseAccess();
           var phraseList =  pa.getMatchingNodes(phr);
            if(phraseList.Count == 0)
            {
                Node<Phrase> nr = pa.InsertNode(phr, new Dictionary<string, object>());
                return nr;
            }
            return null;

        }

        public string LoadDictionaryFile(string fileName)
        {
            string xmlString;
            StringBuilder output = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string wordXML = string.Empty;
                    while (!sr.EndOfStream)
                    {
                        xmlString = sr.ReadLine();
                        if (xmlString.Contains("<p><ent>"))
                        {

                            if (wordXML != string.Empty)
                            {
                                parseWordXML(wordXML);
                            }
                            wordXML = xmlString;
                        }
                        else
                        {
                            wordXML = wordXML + xmlString;
                        }
                    }
                }
         
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;

        }

        private void parseWordXML(string wordXML)
        {
            string word = getInnerText("ent", wordXML);
            string hw = getInnerText("hw", wordXML);
            string pos = getInnerText("pos", wordXML);
            string pr = getInnerText("pr", wordXML);
            string def = getInnerText("def", wordXML);
            string q= getInnerText("q", wordXML);
           
            PartOfSpeechAccess posA = new PartOfSpeechAccess();

            NodeReference<Definition> mdR = null;
            NodeReference<Word> mwR = null;
            PartOfSpeech mPOS = new PartOfSpeech();
            Definition myNewDef = new Definition();
            NodeReference<PartOfSpeech> posR = null;


            mPOS.pos = pos;
            if (pos != string.Empty)
            {
                if (posA.Exists(mPOS))
                {
                    posR = posA.getMatchingNodeReference(mPOS, new Dictionary<string, object>());
                }
                else
                {
                    posR = posA.InsertNodeGetReference(mPOS, new Dictionary<string, object>());
                }
            }


            if (def != string.Empty)
            {
                myNewDef.currentExitation = 0;
                myNewDef.definition = def;
                myNewDef.firePoint = 5;
                myNewDef.lastFired = DateTime.Now;
                mdR = InsertDefinition(myNewDef);
                
            }
            if (word != string.Empty)
            {
                Word myNewWord = new Word();
            myNewWord.currentExitation =0;
            myNewWord.firePoint = 5;
            myNewWord.hw = hw;
            myNewWord.lastFired = DateTime.Now;
            myNewWord.pr = pr;
            myNewWord.word = word;
            mwR = InsertWordByWordGetNodeReference(myNewWord);
            }
            if(mwR != null && mdR != null)
            {
                createWordDefinitionRelationship(mdR, mwR);
            }
            if (mwR != null && posR != null)
            {
                createWordPOSRelationship(posR, mwR);
            }
            return;
        }

        private void createWordPOSRelationship(NodeReference<PartOfSpeech> posR, NodeReference<Word> mwR)
        {
            WordAccess wa = new WordAccess();
            wa.createWordPOSRelationship(posR, mwR);
        }

        private void createWordDefinitionRelationship(NodeReference<Definition> mdR, NodeReference<Word> mwR)
        {
            WordAccess wa = new WordAccess();
            wa.createWordDefinitionRelationship(mdR, mwR);
            //throw new NotImplementedException();
        }

        private NodeReference<Definition> InsertDefinition(Definition myNewDef)
        {
            DefinitionAccess wa = new DefinitionAccess();
            List<Definition> wordList = wa.getMatchingNodes(myNewDef);
            if (wordList == null)
            {
                NodeReference<Definition> nr = wa.InsertNodeGetReference(myNewDef, new Dictionary<string, object>());
                return nr;
            }

            return null;
        }

        private string getInnerText(string v, string wordXML)
        {
            int length = ("<" + v + ">").ToString().Length;
            int i = wordXML.IndexOf("<" + v + ">");
            int j = wordXML.IndexOf("</" + v + ">");
            if (i > -1 && j > i)
            {
                return wordXML.Substring(i + length, (j - i)-length);
            }
            return string.Empty;
        }
    }
}
