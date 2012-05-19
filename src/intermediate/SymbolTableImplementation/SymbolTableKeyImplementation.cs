using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.SymbolTableImplementation
{
    public class SymbolTableKeyImplementation : SymbolTableKey
    {
        // Constant
        public static readonly SymbolTableKeyImplementation CONSTANT_VALUE;

        // Procedure or Function
        public static readonly SymbolTableKeyImplementation ROUTINE_CODE;
        public static readonly SymbolTableKeyImplementation ROUTINE_SYMTAB;
        public static readonly SymbolTableKeyImplementation ROUTINE_ICODE;
        public static readonly SymbolTableKeyImplementation ROUTINE_PARMS;
        public static readonly SymbolTableKeyImplementation ROUTINE_ROUTINES;

        // Variable or Record Field Value
        public static readonly SymbolTableKeyImplementation DATA_VALUES;
    }
}
