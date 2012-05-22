using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface ICodeNode
    {
        //ICodeNodeType GetType();
        //ICodeNode GetParent();
        ICodeNode AddChild(ICodeNode node); // Add a child node.
        List<ICodeNode> GetChildren(); // Return an array list of this node's children.
        void SetAttribute(ICodeKey key, Object value); // Set node attribute.
        Object GetAttribute(ICodeKey key); // Get the value of a node attribute.
        ICodeNode Copy(); // Make a copy of this node.
    }
}
