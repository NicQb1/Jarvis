using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class WordDTO
    {
        public int ID;
        public string word;
        public string partOfSpeech;
        public List<SynonymDTO> synonyms;
        public List<AntonymDTO> antonyms;

    }
}
