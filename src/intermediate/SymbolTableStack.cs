using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface SymbolTableStack
    {
        // int GetCurrentNestingLevel();
        SymbolTable GetLocalSymbolTable();
        SymbolTableEntry EnterLocal(string name);
        SymbolTableEntry LookupLocal(string name);
        SymbolTableEntry Lookup(string name);
    }
}
