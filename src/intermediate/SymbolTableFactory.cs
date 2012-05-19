using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate.SymbolTableImplementation;

namespace Interpreter.intermediate
{
    public class SymbolTableFactory
    {
        public static SymbolTableStack CreateSymbolTableStack()
        {
            return new SymbolTableStackImplementation();
        }

        public static SymbolTable CreateSymbolTable(int nestingLevel)
        {
            return new SymbolTableImplementation.SymbolTableImplementation(nestingLevel);
        }

        public static SymbolTableEntry CreateSymbolTableEntry(string name, SymbolTable symboltable)
        {
            return new SymbolTableEntryImplementation(name, symboltable);
        }
    }
}
