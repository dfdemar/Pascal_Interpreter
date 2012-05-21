using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.SymbolTableImplementation
{
    public class SymbolTableImplementation : SortedList<string, SymbolTableEntry>, SymbolTable
    {
        private int NestingLevel;

        public SymbolTableImplementation(int NestingLevel)
        {
            this.NestingLevel = NestingLevel;
        }

        public int GetNestingLevel()
        {
            return NestingLevel;
        }

        public SymbolTableEntry Enter(string name)
        {
            SymbolTableEntry entry = SymbolTableFactory.CreateSymbolTableEntry(name, this);
            Add(name, entry);
            return entry;
        }

        //  Look up an existing symbol table entry. Null if it does not exist.
        public SymbolTableEntry Lookup(string name)
        {
            return (ContainsKey(name) ? this[name] : null);
        }

        // Return a list of symbol table entries sorted by name.
        public List<SymbolTableEntry> SortedEntries()
        {
            ICollection<SymbolTableEntry> entries = this.Values;
            List<SymbolTableEntry> list = new List<SymbolTableEntry>(Count);
            foreach (SymbolTableEntry entry in entries)
                list.Add(entry);

            return list;
        }
    }
}
