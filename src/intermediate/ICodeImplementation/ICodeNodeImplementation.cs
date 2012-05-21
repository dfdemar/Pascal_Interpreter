using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.ICodeImplementation
{
    public class ICodeNodeImplementation : Dictionary<ICodeKey, Object>, ICodeNode
    {
        public ICodeNodeType type { get; private set; }       // node type
        public ICodeNode parent { get; private set; }         // parent node
        private List<ICodeNode> children;                     // Children list

        public ICodeNodeImplementation(ICodeNodeType type)
        {
            this.type = type;
            this.parent = null;
            this.children = new List<ICodeNode>();
        }

        public ICodeNode AddChild(ICodeNode node)
        {
            if (node != null)
            {
                children.Add(node);
                ((ICodeNodeImplementation)node).parent = this;
            }

            return node;
        }

        public List<ICodeNode> GetChildren()
        {
            return children;
        }

        public void SetAttribute(ICodeKey key, Object value)
        {
            Add(key, value);
        }

        public Object GetAttribute(ICodeKey key)
        {
            return this[key];
        }

        public ICodeNode Copy()
        {
            ICodeNodeImplementation copy = (ICodeNodeImplementation)ICodeFactory.CreateICodeNode(type);
            foreach (KeyValuePair<ICodeKey, Object> KVP in this)
                copy.Add(KVP.Key, KVP.Value);

            return copy;
        }

        public string ToString()
        {
            return type.ToString();
        }
    }
}
