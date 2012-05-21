using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.SymbolTableImplementation
{
    public class SymbolTableEntryImplementation : Dictionary<SymbolTableKey, Object>, SymbolTableEntry
    {
        public string name { get; private set; }
        public SymbolTable symbolTable { get; private set; }
        private List<int> lineNumbers;

        public SymbolTableEntryImplementation(string name, SymbolTable symbolTable)
        {
            this.name = name;
            this.symbolTable = symbolTable;
            this.lineNumbers = new List<int>();
        }

        public string GetName()
        {
            return name;
        }

        public SymbolTable GetSymbolTable()
        {
            return symbolTable;
        }

        public void AppendLineNumber(int lineNumber)
        {
            lineNumbers.Add(lineNumber);
        }

        public List<int> GetLineNumbers()
        {
            return lineNumbers;
        }

        public Object GetAttribute(SymbolTableKey key)
        {
            return this[key];
        }

        public void SetAttribute(SymbolTableKey key, Object value)
        {
            this.Add(key, value);
        }
    }
}
