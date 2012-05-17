using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface SymbolTableEntry
    {
        public string GetName();                                    // Return the name of the entry.
        public SymbolTable GetSymbolTable();                        // Return the symbol table that contains this entry.
        public void AppendLineNumber(int lineNumber);               // Append a source line number to the entry.
        public List<int> GetLineNumbers();                          // Append a source line number to the entry.
        public void SetAttribute(SymbolTableKey key, Object value); // Set an attribute of the entry.
        public Object GetAttribute(SymbolTableKey key);             // Get the value of an attribute of the entry.
    }
}
