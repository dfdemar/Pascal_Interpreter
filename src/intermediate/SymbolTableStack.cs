using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface SymbolTableStack
    {
        public int GetCurrentNestingLevel();
        public SymbolTable GetLocalSymbolTable();
        public SymbolTableEntry EnterLocal(string name);
        public SymbolTableEntry LookupLocal(string name);
        public SymbolTableEntry Lookup(string name);
    }
}
