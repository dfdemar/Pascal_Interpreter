using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface ICodeNode
    {
        public ICodeNodeType GetType();
        public ICodeNode GetParent();
        public ICodeNode AddChild(ICodeNode node); // Add a child node.
        public List<ICodeNode> GetChildren(); // Return an array list of this node's children.
        public void SetAttribute(ICodeKey key, Object value); // Set node attribute.
        public Object GetAttribute(ICodeKey key); // Get the value of a node attribute.
        public ICodeNode Copy(); // Make a copy of this node.
    }
}
