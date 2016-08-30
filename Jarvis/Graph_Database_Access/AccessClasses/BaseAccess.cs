﻿using Neo4jClient;
using Net.Graph.Neo4JD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.AccessClasses
{
    public abstract class BaseAccess<T> where T:BusinessObjects.BOBase
    {
        private  GraphClient _client;
        public virtual GraphClient client
        {
            get
            {
                if (_client == null)
                {
                    _client = new GraphClient(new Uri("http://localhost:7474/db/data"),"neo4j","Maiya581321");
                }
                if (!_client.IsConnected)
                {
                    _client.Connect();
                }
                return _client;

            }
           
        }

        private T getUniqueNode(T node)
        {
            try
            {
                List<T> results = client.Cypher.Match("(t:T)")
                     .Where((T t) => t.Id == node.Id)
                     .Return(command => command.As<T>())
                     .Results
                     .ToList();

                return results.First();
            }
            catch { return null; }
        }
    

        public   void AddEdge(long node1Id, string relatioinship, long node2Id, Dictionary<string, object> myDictionary, bool directed = false)
        {
             client.Cypher
                    .Match("(n1)", "(n2)")
                    .Where((T n1) => n1.Id == node1Id)
                    .AndWhere((T n2) => n2.Id == node2Id)
                    .CreateUnique("n1-[:{" + relatioinship + "}]->n2")
                    .WithParams(myDictionary)
                    .ExecuteWithoutResultsAsync();
            //return node1Id;
        }

        public virtual bool exciteNode(NodeReference<T> nodeRef, int exitationAmount)
        {

            var myNode = client.Update(
                nodeRef,
                node =>
                {
                    node.currentExitation = node.currentExitation + exitationAmount;
                });
            if (myNode.Data.currentExitation >= myNode.Data.firePoint)
            {
                List<Node> myNodes = new List<Node>();

                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual List<T> getMatchingNodes(T node,Dictionary<string,object> myDictionary)
        {
            try { 
            List<T> results  = client.Cypher.Match("(t:T)")
                 .Where((T t) => t.Id == node.Id)
                 .WithParams(myDictionary)
                 .Return(command => command.As<T>())
                 .Results
                 .ToList();
        
            return results;
        }catch {
                return null; }
        }
        public virtual NodeReference<T> getMatchingNodeReference(T node, Dictionary<string, object> myDictionary)
        {
            try
            {
                var results = client.Cypher.Match("(t:T)")
                     .Where((T t) => t.Id == node.Id)
                     .Return<T>("x");
                if(results==null)
                {
                    return client.Create(node);
                }


            return (NodeReference<T>)results;
            }
            catch(Exception ex)
            { return null; }
        }

        public virtual List<T> getMatchingNodes(T node)
        {
         
            try
            {
                var results = client.Cypher.Match("(t:T)")
               .Where((T t) => t.Id == node.Id)
               .Return(t => t.As<T>())
               .Results.ToList();


                return results;
            }catch (Exception ex)
            { return null; }
        }

        public virtual List<Node> getChildNodes(NodeReference<T> nodeRef)
        {
            throw new NotImplementedException();
        }

        public virtual bool exciteNode(T node, int exitationAmount)
        {
            throw new NotImplementedException();
        }

        public virtual void InsertNode(T newNode, Dictionary<string, object> myDictionary, string label)
        {
            try
            {

                client.Cypher
                      .Merge("(node:" + label + ")")
                      .OnCreate()
                      .Set("node. = {" + newNode.Id + "}")
                      .WithParams(myDictionary)
                      .ExecuteWithoutResults();

            }
            catch (Exception ex)
            {
                return;
            }

        }
        protected BaseAccess()
        {
        }
    }
}
