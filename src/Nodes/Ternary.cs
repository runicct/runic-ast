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
            public class Ternary : Expression
            {
                Expression _condition;
                public Expression Condition { get { return _condition; } }
                Expression _true;
                public Expression True { get { return _true; } }
                Expression _false;
                public Expression False { get { return _false; } }
                public override Type Type { get { return _true.Type; } }
#if NET6_0_OR_GREATER
                public Ternary(int startLine, int startColumn, int endLine, int endColumn, string? file, Expression condition, Expression @true, Expression @false) : base(startLine, startColumn, endLine, endColumn, file)
#else
                public Ternary(int startLine, int startColumn, int endLine, int endColumn, string file, Expression condition, Expression @true, Expression @false): base(startLine, startColumn, endLine, endColumn, file)
#endif
                {
                    _condition = condition;
                    _true = @true;
                    _false = @false;
                    if (_false.Type != _true.Type)
                    {
                        throw new Exception("Type mismatch in Add expression");
                    }
                }
                public Ternary(Expression condition, Expression @true, Expression @false) : this(-1, -1, -1, -1, null, condition, @true, @false) { }
            }
        }
    }
}
