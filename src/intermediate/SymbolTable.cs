using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface SymbolTable
    {
        public int GetNestingLevel();
        public SymbolTableEntry Enter(string name);    // Create and enter a new entry into the symbol table.
        public SymbolTableEntry Lookup(string name);   // Look up an existing symbol table entry.
        public List<SymbolTableEntry> SortedEntries(); // Return a list of symbol table entries sorted by name.
    }
}
