using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.SymbolTableImplementation
{
    public class SymbolTableImplementation : SortedList<string, SymbolTableEntry>, SymbolTable
    {
        public int NestingLevel { get; private set; }

        public SymbolTableImplementation(int NestingLevel)
        {
            this.NestingLevel = NestingLevel;
        }

        public SymbolTableEntry Enter(string name)
        {
            SymbolTableEntry entry = SymbolTableFactory.CreateSymbolTableEntry(name, this);
            Add(name, entry);
            return entry;
        }

        public SymbolTableEntry Lookup(string name)
        {
            return this[name];
        }

        // Return a list of symbol table entries sorted by name.
        public List<SymbolTableEntry> SortedEntries()
        {

        }
    }
}
