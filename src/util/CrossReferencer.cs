using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.intermediate.SymbolTableImplementation;

namespace Interpreter.util
{
    public class CrossReferencer
    {
        private static readonly int NAME_WIDTH = 16;

        private static readonly string NAME_FORMAT = "{0,-16}";
        private static readonly string NUMBERS_LABEL = " Line numbers    ";
        private static readonly string NUMBERS_UNDERLINE = " ------------    ";
        private static readonly string NUMBER_FORMAT = " {0:000}";

        private static readonly int LABEL_WIDTH  = NUMBERS_LABEL.Length;
        private static readonly int INDENT_WIDTH = NAME_WIDTH + LABEL_WIDTH;

        private static readonly StringBuilder INDENT = new StringBuilder(INDENT_WIDTH);

        static CrossReferencer()
        {
            for (int i = 0; i < INDENT_WIDTH; ++i)
                INDENT.Append(" ");
        }

        // Print the cross reference table
        public void Print(SymbolTableStack symbolTableStack)
        {
            Console.WriteLine("\n===== CROSS-REFERENCE TABLE =====");
            PrintColumnHeadings();
            PrintSymbolTable(symbolTableStack.GetLocalSymbolTable());
        }

        private void PrintColumnHeadings()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format(NAME_FORMAT, "Identifier") + NUMBERS_LABEL);
            Console.WriteLine(String.Format(NAME_FORMAT, "----------") + NUMBERS_UNDERLINE);
        }

        private void PrintSymbolTable(SymbolTable symbolTable)
        {
            List<SymbolTableEntry> sorted = symbolTable.SortedEntries();
            foreach (SymbolTableEntry entry in sorted)
            {
                List<int> lineNumbers = entry.GetLineNumbers();
                Console.Write(String.Format(NAME_FORMAT, entry.GetName()));
                if (lineNumbers != null)
                {
                    foreach (int lineNumber in lineNumbers)
                        Console.Write(String.Format(NUMBER_FORMAT, lineNumber));
                }

                Console.WriteLine();
            }
        }
    }
}
