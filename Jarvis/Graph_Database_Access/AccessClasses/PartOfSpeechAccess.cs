using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace Graph_Database_Access.AccessClasses
{
    public class PartOfSpeechAccess : BaseAccess<PartOfSpeech>, IGDBAccess<PartOfSpeech>
    {
        public PartOfSpeech GetObjectClass(object value)
        {
            var result = client.Cypher.Match("(partOfSpeech:PartOfSpeech)")
                 .Where((PartOfSpeech partOfSpeech) => partOfSpeech.pos == (string)value)
                 .Return(partOfSpeech => partOfSpeech.As<PartOfSpeech>())
                 .Results
                 .Single();
            return result;
        }

        public PartOfSpeech getPOS(object p)
        {
            PartOfSpeech result = new PartOfSpeech();
            result.currentExitation = ((PartOfSpeech)p).currentExitation;
            result.firePoint = ((PartOfSpeech)p).firePoint;
            result.Id = ((PartOfSpeech)p).Id;
            result.lastFired = ((PartOfSpeech)p).lastFired;
            result.pos = ((PartOfSpeech)p).pos;
            return result;
            // throw new NotImplementedException();
        }

        public override NodeReference<PartOfSpeech> getMatchingNodeReference(PartOfSpeech node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher.Match("(partOfSpeech:PartOfSpeech)")
                    .Where((PartOfSpeech partOfSpeech) => partOfSpeech.pos == node.pos)
                 .Return<PartOfSpeech>("x");

                if (results == null)
                {
                    return client.Create(node);
                }


                return (NodeReference < PartOfSpeech > )results;
            }
            catch (Exception ex)
            { return null; }
        }

        public NodeReference<PartOfSpeech> getMatchingNodeReference(PartOfSpeech node)
        {
            try
            {
                var results = client.Cypher.Match("(partOfSpeech:PartOfSpeech)")
   .Where((PartOfSpeech partOfSpeech) => partOfSpeech.pos == node.pos)
   .Return(partOfSpeech => partOfSpeech.As<PartOfSpeech>())
   .Results;
                if (results == null)
                {
                    return client.Create(node);
                }


                return (NodeReference<PartOfSpeech>)results;
            }
            catch (Exception ex)
            { return null; }
        }

        public bool Exists(PartOfSpeech node)
        {
            try
            {
                var results = client.Cypher
                    .Match("(c:PartOfSpeech)")
                    .Where((PartOfSpeech c) => c.pos == node.pos)
                    .Return(c => c.As<PartOfSpeech>())
                    .Results
                    .Any();

                //var results = client.Cypher.Match("(partOfSpeech:PartOfSpeech)")
                //    .Where((PartOfSpeech partOfSpeech) => partOfSpeech.pos == node.pos)
                //    .Return(partOfSpeech => partOfSpeech.As<PartOfSpeech>())
                //    .Results
                //    .Any();

                return results;
            }catch(Exception ex)
            {
                return false;
                //throw;
            }

        }
    }
}
