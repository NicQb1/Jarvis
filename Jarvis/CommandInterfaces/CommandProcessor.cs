using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Database_Access;
using Common.DTO;
using SQL_Database_Access;
using Graph_Database_Access.AccessClasses;

namespace CommandInterfaces
{
    public class CommandProcessor
    {
        public GraphDB gb = new GraphDB();
        public WordLogic wl = new WordLogic();
        public PartOfSpeechLogic pl = new PartOfSpeechLogic();

        public void ExecuteCommand(string results)
        {

            WordAccess wa = new WordAccess();
            //Check Do all words exist in Graph DB?
            List<WordDTO> words = gb.getWords(results);
            if(words.Where(e=>e.ID <= 0).Any())
            {
               
                foreach(var word in words)
                {
                    if(word.ID <= 0)
                    {
                     List<  WordDTO> tmp = wl.GetWord(word.word);
                       var wordRef = gb.Insert_Word_Node(tmp[0].word, tmp[0].ID);
                        foreach (var wrd in tmp)
                        {
                            var posRef = pl.GetPartOfSpeech(wrd.partOfSpeech);
                            gb.createWordPOSRelationship(posRef, wordRef);
                            foreach(var syn in wrd.synonyms)
                            {
                                var synRef = gb.Insert_Word_Node(syn.word, syn.wordID);
                                gb.createWordSynonymRelationship(wordRef, synRef);

                            }
                        }
                        
                    }

                }
                words = gb.getWords(results);

            }
            foreach (var word in words)
            {
                wa.exciteNode(wa.getWordRef(word));

            }
        }

        public void insertMissingWords(string word)
        {
            List<WordDTO> tmp = wl.GetWord(word);
            var wordRef = gb.Insert_Word_Node(tmp[0].word, tmp[0].ID);
            foreach (var wrd in tmp)
            {
                var posRef = pl.GetPartOfSpeech(wrd.partOfSpeech);
                gb.createWordPOSRelationship(posRef, wordRef);
                foreach (var syn in wrd.synonyms)
                {
                    List<WordDTO> words = gb.getWords(syn.word);
                    if(words.Where(e=>e.ID <=0).Any())
                    {
                        foreach(var synWord in words)
                        {
                            if(synWord.ID<=0)
                            {
                                insertMissingWords(synWord.word);
                            }
                        }
                       

                    }
                    var synRef = gb.Insert_Word_Node(syn.word, syn.wordID);
                    gb.createWordSynonymRelationship(wordRef, synRef);

                }
            }

        }

    }
}
