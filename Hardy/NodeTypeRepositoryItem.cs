using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardy
{
    public class NodeTypeRepositoryItem
    {
        public string Name { get; set; }
        public NodeType Val { get; set; }

        public NodeTypeRepositoryItem(string name, NodeType value)
        {
            this.Name = name;
            this.Val = value;
        }

        public static List<NodeTypeRepositoryItem> GetStockItems()
        {
            List<NodeTypeRepositoryItem> items = new List<NodeTypeRepositoryItem>();
            items.Add(new NodeTypeRepositoryItem("Node", NodeType.Node));
            items.Add(new NodeTypeRepositoryItem("Pump", NodeType.Pump));
            items.Add(new NodeTypeRepositoryItem("Container", NodeType.Container));
            items.Add(new NodeTypeRepositoryItem("Reservoir", NodeType.Reservoir));
            items.Add(new NodeTypeRepositoryItem("Unspecified", NodeType.Unspecified));
            return items;
        }
    }
}