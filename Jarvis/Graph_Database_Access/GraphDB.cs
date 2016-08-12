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
using System.Text;


namespace Graph_Database_Access
{
    public class GraphDB
    {
       
        public void CreateIndexes()
        {

        }

        private NodeReference<Word> InsertWord(string word)
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
                NodeReference<Word> nr = wa.InsertNode(myword, new Dictionary<string, object>());
                return nr;
            }
           
                return null ;
            

           
        }

        private NodeReference<Word> InsertWord(Word myword)
        {
           
            WordAccess wa = new WordAccess();
            List<Word> wordList = wa.getMatchingNodes(myword);
            if (wordList == null)
            {
                NodeReference<Word> nr = wa.InsertNode(myword, new Dictionary<string, object>());
                return nr;
            }

            return null;

        }

        public NodeReference<Phrase> InsertPhrase(string phrase)
        {
            var phr = new Phrase();
            phr.phrase = phrase;
            PhraseAccess pa = new PhraseAccess();
           var phraseList =  pa.getMatchingNodes(phr);
            if(phraseList.Count == 0)
            {
                NodeReference<Phrase> nr = pa.InsertNode(phr, new Dictionary<string, object>());
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
                          
                            if(wordXML != string.Empty)
                            {
                                parseWordXML(wordXML);
                            }
                            wordXML = xmlString;
                        }else
                        {
                            wordXML = wordXML+ xmlString;
                        }
                    }



                }

                

                //using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                //{
                //    XmlWriterSettings ws = new XmlWriterSettings();
                //    ws.Indent = true;
                //    using (XmlWriter writer = XmlWriter.Create(output, ws))
                //    {

                //        // Parse the file and display each of the nodes.
                //        while (reader.Read())
                //        {
                //            try
                //            {
                //                switch (reader.NodeType)
                //                {
                //                    case XmlNodeType.Element:
                //                        writer.WriteStartElement(reader.Name);
                //                        break;
                //                    case XmlNodeType.Text:
                //                        writer.WriteString(reader.Value);
                //                        break;
                //                    case XmlNodeType.XmlDeclaration:
                //                    case XmlNodeType.ProcessingInstruction:
                //                        writer.WriteProcessingInstruction(reader.Name, reader.Value);
                //                        break;
                //                    case XmlNodeType.Comment:
                //                        writer.WriteComment(reader.Value);
                //                        break;
                //                    case XmlNodeType.EndElement:
                //                        writer.WriteFullEndElement();
                //                        break;
                //                }
                //            }catch { }
                //        }
                //        string results = output.ToString();
                //        return results;

                //    }
                //}
            }
            catch (Exception ex)
            {
               
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
            Definition myNewDef = new Definition();
            myNewDef.currentExitation = 0;
            myNewDef.definition = def;
            myNewDef.firePoint = 5;
            myNewDef.lastFired = DateTime.Now;
            NodeReference<Definition> mdR = null;
            NodeReference<Word> mwR = null;
            if (myNewDef.definition!= string.Empty)
            {
                mdR =InsertDefinition(myNewDef);
            }
            Word myNewWord = new Word();
            myNewWord.currentExitation =0;
            myNewWord.firePoint = 5;
            myNewWord.hw = hw;
            myNewWord.lastFired = DateTime.Now;
            myNewWord.pr = pr;
            myNewWord.word = word;
            if (word != string.Empty)
            {
                 mwR = InsertWord(myNewWord);
            }
            if(mwR != null && mdR != null)
            {
                createWordDefinitionRelationship(mdR, mwR);
            }
            return;
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
                NodeReference<Definition> nr = wa.InsertNode(myNewDef, new Dictionary<string, object>());
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
