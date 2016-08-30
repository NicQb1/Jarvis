using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Common.DTO;

namespace Graph_Database_Access.AccessClasses
{
    public class PartOfSpeechAccess : BaseAccess<PartOfSpeech>, IGDBAccess<PartOfSpeech>
    {
        #region Get Methods
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
                    .Where(" pos.pos = '" + node.pos + "'")
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
                    .Match("(pos:PartOfSpeech)")
                    .Where( " pos.pos = '" + node.pos +"'")
                    .Return(pos => pos.As<PartOfSpeech>())
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
        #endregion

        #region Insert Methods

        public virtual PartOfSpeech CreateNode(PartOfSpeech node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(pos:PartOfSpeech {pos})")
                     .WithParam("pos", node)
                     .Return(pos => pos.As<PartOfSpeech>())
                     .Results;

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public  PartOfSpeech InsertNodeGetReference(PartOfSpeech node, Dictionary<string, object> myDictionary)
        {
            try
            {
               // var myNodeReference = client.Create(node);
               // return myNodeReference;
                var results = client.Cypher
                     .Create("(pos:PartOfSpeech {pos})")
                     .WithParam("pos", node)
                     .Return(word => word.As<PartOfSpeech>())
                     .Results;

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public NodeReference<PartOfSpeech> InsertNodeGetRef(PartOfSpeech node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(pos:PartOfSpeech  {pos})")
                     .WithParam("pos", node)
                     .Return(pos => pos.As<PartOfSpeech>())
                     .Results;
                var x = client.Get<PartOfSpeech>((NodeReference)results.First().Id);

                return x.Reference;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        public PartOfSpeech InsertNode(PartOfSpeech node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(pos:PartOfSpeech {pos})")
                     .WithParam("pos", node)
                     .Return(pos => pos.As<PartOfSpeech>())
                     .Results;

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool exciteNode(NodeReferenceStats nRefS)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
