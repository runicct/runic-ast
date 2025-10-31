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
            public class Comparison : Expression
            {
                Expression _left;
                public Expression Left { get { return _left; } }
                Expression _right;
                public Expression Right { get { return _right; } }
                public enum ComparisonOperation
                {
                    Equal = 0,
                    NotEqual = 1,
                    LowerThan = 2,
                    GreaterThan = 3,
                    LowerOrEqual = 4,
                    GreaterOrEqual = 5,
                }
                ComparisonOperation _operation;
                public ComparisonOperation Operation { get { return _operation; } }
                public override Type Type { get { return Type._bool; } }
#if NET6_0_OR_GREATER
                public Comparison(int startLine, int startColumn, int endLine, int endColumn, string? file, ComparisonOperation operation, Expression left, Expression right) : base(startLine, startColumn, endLine, endColumn, file)
#else
                public Comparison(int startLine, int startColumn, int endLine, int endColumn, string file, ComparisonOperation operation, Expression left, Expression right) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                {
                    _operation = operation;
                    _left = left;
                    _right = right;
                    if (_left.Type != _right.Type)
                    {
                        throw new Exception("Type mismatch in Comparison expression");
                    }
                }
                public Comparison(ComparisonOperation operation, Expression left, Expression right) : this(-1, -1, -1, -1, null, operation, left, right) { }
            }
        }
    }
}
