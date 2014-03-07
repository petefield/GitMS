using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitMS.Models
{
    public class Node
    {
        public Guid Id { get; set; }
        public Guid Parent { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }
        public String View { get; set;  }
        public IEnumerable<Field> Fields { get; set;  }
    }

    public class Field
    {
        public Guid Id { get; set; }
        public Guid Node { get; set;  }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Value { get; set; }
    }


}