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
            public class Rem : Expression
            {
                Expression _left;
                public Expression Left { get { return _left; } }
                Expression _right;
                public Expression Right { get { return _right; } }
                public override Type Type { get { return _left.Type; } }
#if NET6_0_OR_GREATER
                public Rem(int startLine, int startColumn, int endLine, int endColumn, string? file, Expression left, Expression right) : base(startLine, startColumn, endLine, endColumn, file)
#else
                public Rem(int startLine, int startColumn, int endLine, int endColumn, string file, Expression left, Expression right) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                {
                    _left = left;
                    _right = right;
                    if (_left.Type != _right.Type)
                    {
                        throw new Exception("Type mismatch in Mod expression");
                    }
                }
                public Rem(Expression left, Expression right) : this(-1, -1, -1, -1, null, left, right) { }
            }
        }
    }
}
