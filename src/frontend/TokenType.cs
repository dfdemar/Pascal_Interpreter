﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend
{
    public interface TokenType
    {
        string GetName();
        string ToString();
    }
}
