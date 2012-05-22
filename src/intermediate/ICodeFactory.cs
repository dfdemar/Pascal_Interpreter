using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate.ICodeImplementation;

namespace Interpreter.intermediate
{
    public class ICodeFactory
    {
        // Create and return an intermediate code implementation.
        public static ICode CreateICode()
        {
            return new ICodeImplementation.ICodeImplementation();
        }

        // Create and return a node implementation.
        public static ICodeNode CreateICodeNode(ICodeNodeType type)
        {
            return new ICodeNodeImplementation(type);
        }
    }
}
