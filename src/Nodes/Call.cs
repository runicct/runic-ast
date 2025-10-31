/*
 * MIT License
 * 
 * Copyright (c) 2025 Runic Compiler Toolkit Contributors
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runic.AST
{
    public abstract partial class Node
    {
        public abstract partial class Expression : Node
        {
            public class Call : Expression
            {
                Function _function;
                public Function Function { get { return _function; } }
                Expression[] _parameters;
                public Expression[] Parameters { get { return _parameters; } }
                public override Type Type { get { return _function.ReturnType; } }
#if NET6_0_OR_GREATER
                public Call(int startLine, int startColumn, int endLine, int endColumn, string? file, Function function, Expression[] parameters) : base(startLine, startColumn, endLine, endColumn, file)
#else
                public Call(int startLine, int startColumn, int endLine, int endColumn, string file, Function function, Expression[] parameters) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                {
                    _function = function;
                    _parameters = parameters;
                    if (_function.Parameters.Length != _parameters.Length)
                    {
                        throw new Exception("Parameter count mismatch in function call");
                    }
                    for (int n = 0; n < _parameters.Length; n++)
                    {
                        if (_parameters[n].Type != _function.Parameters[n].Type)
                        {
                            throw new Exception("Parameter type mismatch in function call at parameter " + n.ToString());
                        }
                    }
                }
                public Call(Function function, Expression[] parameters) : this(-1, -1, -1, -1, null, function, parameters) { }
            }
        }
    }
}
