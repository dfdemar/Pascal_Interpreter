using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.intermediate.ICodeImplementation;

namespace Interpreter.util
{
    public class ParseTreePrinter
    {
        private static readonly int INDENT_WIDTH = 4;
        private static readonly int LINE_WIDTH = 80;

        private TextWriter tw;
        private int length;
        private string indent;
        private string indentation;
        private StringBuilder line;

        public ParseTreePrinter(TextWriter tw)
        {
            this.tw = tw;
            this.length = 0;
            this.indentation = "";
            this.line = new StringBuilder();

            this.indent = "";
            for(int i = 0; i < INDENT_WIDTH; ++i)
                this.indent += " ";
        }

        public void Print(ICode iCode)
        {
            tw.WriteLine("\n===== INTERMEDIATE CODE =====\n");
            PrintNode((ICodeNodeImplementation)iCode.GetRoot());
            PrintLine();
        }

        // Print a parse tree node.
        private void PrintNode(ICodeNodeImplementation node)
        {
            Append(indentation);
            Append("<" + node.ToString());
            PrintAttributes(node);
            PrintTypeSpecification(node);

            List<ICodeNode> childNodes = node.GetChildren();

            // Print the node's children followed by the closing tag.
            if ((childNodes != null) && (childNodes.Count() > 0))
            {
                Append(">");
                PrintLine();

                PrintChildNodes(childNodes);
                Append(indentation);
                Append("</" + node.ToString() + ">");
            }
            else
                Append(" />");  // No children: Close off the tag

            PrintLine();
        }

        // Print a parse tree node's attributes.
        private void PrintAttributes(ICodeNodeImplementation node)
        {
            string saveIndentation = indentation;
            indentation += indent;

            foreach (KeyValuePair<ICodeKey, Object> KVP in node)
                PrintAttribute(KVP.Key.ToString(), KVP.Value);
        }

        private void PrintAttribute(string keyString, Object value)
        {
            // If the value is a symbol table entry, use the identifier's name.
            // Else just use the value string.
            bool isSymbolTableEntry = value is SymbolTableEntry;
            string valueString = isSymbolTableEntry ? ((SymbolTableEntry)value).GetName() : value.ToString();

            // Include an identifier's nesting level.
            if (isSymbolTableEntry)
            {
                int level = ((SymbolTableEntry)value).GetSymbolTable().GetNestingLevel();
                PrintAttribute("LEVEL", level);
            }
        }

        // Print a parse tree node's child nodes.
        private void PrintChildNodes(List<ICodeNode> childNodes)
        {
            string saveIndentation = indentation;
            indentation += indent;

            foreach (ICodeNode child in childNodes)
                PrintNode((ICodeNodeImplementation)child);

            indentation = saveIndentation;
        }

        // Print a parse tree node's type specification.
        private void PrintTypeSpecification(ICodeNodeImplementation node)
        {
        }

        // Append text to the output line.
        private void Append(string text)
        {
            int textLength = text.Length;
            bool lineBreak = false;

            // Wrap lines that are too long.
            if (length + textLength > LINE_WIDTH)
            {
                PrintLine();
                line.Append(indentation);
                length = indentation.Length;
                lineBreak = true;
            }

            // Append the text.
            if (!(lineBreak && text.Equals(" ")))
            {
                line.Append(text);
                length += textLength;
            }
        }

        // Print an output line.
        private void PrintLine()
        {
            if (length > 0)
            {
                tw.WriteLine(line);
                line.Length = 0;
                length = 0;
            }
        }
    }
}
