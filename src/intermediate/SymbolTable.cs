using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface SymbolTable
    {
        int GetNestingLevel();
        SymbolTableEntry Enter(string name);    // Create and enter a new entry into the symbol table.
        SymbolTableEntry Lookup(string name);   // Look up an existing symbol table entry.
        List<SymbolTableEntry> SortedEntries(); // Return a list of symbol table entries sorted by name.
    }
}
