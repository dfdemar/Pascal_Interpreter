using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.SymbolTableImplementation
{
    public class SymbolTableKeyImplementation : SymbolTableKey
    {
        // Constant
        public static readonly SymbolTableKeyImplementation CONSTANT_VALUE = new SymbolTableKeyImplementation();

        // Procedure or Function
        public static readonly SymbolTableKeyImplementation ROUTINE_CODE = new SymbolTableKeyImplementation();
        public static readonly SymbolTableKeyImplementation ROUTINE_SYMTAB = new SymbolTableKeyImplementation();
        public static readonly SymbolTableKeyImplementation ROUTINE_ICODE = new SymbolTableKeyImplementation();
        public static readonly SymbolTableKeyImplementation ROUTINE_PARMS = new SymbolTableKeyImplementation();
        public static readonly SymbolTableKeyImplementation ROUTINE_ROUTINES = new SymbolTableKeyImplementation();

        // Variable or Record Field Value
        public static readonly SymbolTableKeyImplementation DATA_VALUES = new SymbolTableKeyImplementation();
    }
}
