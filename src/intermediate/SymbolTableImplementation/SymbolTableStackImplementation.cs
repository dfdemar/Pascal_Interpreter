using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.SymbolTableImplementation
{
    public class SymbolTableStackImplementation : List<SymbolTable>, SymbolTableStack
    {
        public int CurrentNestingLevel { get; private set; }  // Current scope nesting level

        public SymbolTableStackImplementation()
        {
            this.CurrentNestingLevel = 0;
            Add(SymbolTableFactory.CreateSymbolTable(CurrentNestingLevel));
        }

        // Return the local symbol table which is at the top of the stack.
        public SymbolTable GetLocalSymbolTable()
        {
            return this[CurrentNestingLevel];
        }

        public SymbolTableEntry EnterLocal(string name)
        {
            return this[CurrentNestingLevel].Enter(name);
        }

        public SymbolTableEntry LookupLocal(string name)
        {
            return this[CurrentNestingLevel].Lookup(name);
        }

        public SymbolTableEntry Lookup(string name)
        {
            return LookupLocal(name);
        }
    }
}
