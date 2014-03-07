using GitMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitMS.Controllers
{
    public class NodeController : ApiController
    {
        // GET api/values
        public IEnumerable<Node> Get() {

            return NodeStore.Repository.Nodes;

        }


        // GET api/values/5
        public Node Get(string id) {

            var node = NodeStore.Repository.Read(id);
            return node;

        }

        // POST api/values
        public void Post([FromBody]Node node) {
        
            NodeStore.Repository.Create(node);

        }

        // PUT api/values/5
        public void Put([FromBody]Node node) {

            NodeStore.Repository.Update(node);  
        
        }

        // DELETE api/values/5
        public void Delete(string id) {

            var node = NodeStore.Repository.Nodes.Single(n => n.Id == Guid.Parse(id));
            NodeStore.Repository.Delete(node);

        }
    }
}