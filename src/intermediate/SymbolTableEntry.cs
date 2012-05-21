using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface SymbolTableEntry
    {
        string GetName();                                    // Return the name of the entry.
        SymbolTable GetSymbolTable();                        // Return the symbol table that contains this entry.
        void AppendLineNumber(int lineNumber);               // Append a source line number to the entry.
        List<int> GetLineNumbers();                          // Append a source line number to the entry.
        void SetAttribute(SymbolTableKey key, Object value); // Set an attribute of the entry.
        Object GetAttribute(SymbolTableKey key);             // Get the value of an attribute of the entry.
    }
}
