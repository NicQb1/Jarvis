﻿using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.AccessClasses
{
    public class SemanticPairsAccess : BaseAccess<SemanticPairs>, IGDBAccess<SemanticPairs>
    {
        public bool Exists(SemanticPairs node)
        {

            return client.Cypher.Match("(semanticPairs:SemanticPairs)")
                 .Where(" semanticPairs.pos1 = '" + node.pos1 + "' AND  semanticPairs.pos2 = '" + node.pos2 + "'")
                 .Return(semanticPairs => semanticPairs.As<SemanticPairs>())
                 .Results
                 .Any();
        }

        public SemanticPairs GetObjectClass(object value)
        {
            return client.Cypher.Match("(semanticPairs:SemanticPairs)")
                 .Where(" semanticPairs.pos1 = '" + ((SemanticPairs)value).pos1 + "' AND  semanticPairs.pos2 = '" + ((SemanticPairs)value).pos2 + "'")
                 .Return(semanticPairs => semanticPairs.As<SemanticPairs>())
                 .Results
                .Single();
          
        }

        public SemanticPairs InsertNode(SemanticPairs node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(semanticPairs:SemanticPairs {semanticPairs})")
                     .WithParam("semanticPairs", node)
                     .Return(semanticPairs => semanticPairs.As<SemanticPairs>())
                     .Results;

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}