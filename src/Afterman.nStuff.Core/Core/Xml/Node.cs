using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Xml
{
    using System.IO;
    using System.Xml;

    public class Node
    {
        public Node()
        {
            this.Nodes = new List<Node>();
            this.Attributes = new List<NodeAttribute>();
        }

        public Node(Node parentNode)
            : this()
        {
            this.ParentNode = parentNode;
        }

        public Node(string name, Node parentNode)
            : this()
        {
            this.ParentNode = parentNode;
            this.Name = name;
        }

        public Node(string name)
            : this()
        {
            this.Name = name;
        }

        protected Node ParentNode { get; set; }
        protected string Name { get; set; }

        protected List<Node> Nodes { get; set; }

        protected List<NodeAttribute> Attributes { get; set; }

        protected string Value { get; set; }

        public Node RootElement()
        {
            var node = this;
            while (null != node.ParentNode)
            {
                node = node.ParentNode;
            }
            return node;
        }

        public Node Parent()
        {
            return this.ParentNode;
        }



        public Node AddNode(string name)
        {
            var node = new Node()
            {
                Name = name,
                ParentNode = this,
            };
            this.Nodes.Add(node);
            return node;
        }

        public Node AddNode(Node node)
        {
            this.Nodes.Add(node);
            return node;
        }

        public Node AddNodeIf(string name, bool condition)
        {
            var node = new Node()
            {
                Name = name,
                ParentNode = this,
            };
            if (condition)
                this.Nodes.Add(node);
            return node;
        }

        public Node AddAttribute<T>(string name, T value)
        {
            var strValue = value?.ToString();
            if (String.IsNullOrEmpty(strValue))
                return this;
            if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            {
                var boolValue = (bool?)(object)value;
                strValue = boolValue.HasValue && boolValue.Value ? "Y" : "N";
            }
            if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            {
                var dateValue = (DateTime?)(object)value;
                strValue = dateValue.HasValue ? dateValue.Value.ToString("yyyy-MM-dd") : String.Empty;
            }
            this.Attributes.Add(new NodeAttribute()
            {
                Name = name,
                Value = strValue,
            });
            return this;
        }

        public Node AddValue(string value)
        {
            this.Value = value;
            return this;
        }

        public override string ToString()
        {
            using (var stream = new StringWriter())
            using (var writer = new XmlTextWriter(stream))
            {
                writer.Formatting = Formatting.Indented;
                this.WriteXml(writer);
                return stream.ToString();
            }
        }

        private void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement(this.Name);
            foreach (var attribute in this.Attributes)
            {
                writer.WriteStartAttribute(attribute.Name);
                writer.WriteString(attribute.Value.ToString());
                writer.WriteEndAttribute();
            }

            writer.WriteString(this.Value);

            foreach (var child in this.Nodes)
            {
                child.WriteXml(writer);
            }
            writer.WriteEndElement();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
