using GitMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GitMS.Repository
{
    public class NodeRepository
    {

        private string _nodeDir;
        private List<Node> _nodes;

        public NodeRepository(string nodeDir) {
            
            _nodeDir = nodeDir;
            _nodes = new List<Node>();

        }

        public void Init() {

            _nodes.Clear();

            foreach(var nodeFile in System.IO.Directory.EnumerateFiles(_nodeDir)) {

                using(StreamReader sr = new StreamReader(nodeFile)) {
                    var node = JsonConvert.DeserializeObject<Node>(sr.ReadToEnd());
                    _nodes.Add(node);
                }

            }

        }

        private String getNodePath(Node node) {
            
            return System.IO.Path.Combine(_nodeDir, string.Format("{0}.json", node.Id.ToString()));

        }

        public List<Node> Nodes {
            get { return _nodes; }
        }

        public Node Update(Node node) {
            //Serialise to disk
            var nodeToReplace = Read(node.Id);
            
            nodeToReplace.Name = node.Name;
            nodeToReplace.Parent = node.Parent;
            nodeToReplace.Fields = node.Fields;
            
            save(node);          
            return node;
        }

        public Node Create(Node node) {
            //Serialise to disk
            node.Id = Guid.NewGuid();
            save(node);
            _nodes.Add(node);
            return node;
        }

        private void save(Node node)
        {
            using(var file = File.Create(getNodePath(node))) {
                using(StreamWriter fs = new StreamWriter(file)) {
                    fs.Write(JsonConvert.SerializeObject(node));
                }
            }
        }

        public Node Read(string id) {
            return Read(Guid.Parse(id));
        }

        public Node Read(Guid id) {
            var node = _nodes.Single(n => n.Id == id);
            return node;
        }

        public Node ReadByPath(String path) {
            var node = _nodes.Single(n => n.Path == path);
            return node;
        }

        public void Delete(Node node) {
            _nodes.Remove(node);
            System.IO.File.Delete(getNodePath(node));
        }

    }
}