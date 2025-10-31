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
using static Runic.AST.Type.StructOrUnion;

namespace Runic.AST
{
    public abstract partial class Node
    {
        public abstract partial class Expression : Node
        {
            public class MemberReference : Expression
            {
                Variable _variable;
                public Variable Variable { get { return _variable; } }
                Field[] _fields;
                public Field[] Fields { get { return _fields; } }
                Type.Pointer _type;
                public override Type Type { get { return _type; } }
#if NET6_0_OR_GREATER
                public MemberReference(int startLine, int startColumn, int endLine, int endColumn, string? file, Variable variable, Field[] fields) : base(startLine, startColumn, endLine, endColumn, file)
#else
                public MemberReference(int startLine, int startColumn, int endLine, int endColumn, string file, Variable variable, Field[] fields) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                {
                    _type = new Type.Pointer(fields[fields.Length - 1].Type);
                    _variable = variable;
                    _fields = fields;
                }
                public MemberReference(Variable variable, Field[] fields) : this(-1, -1, -1, -1, null, variable, fields) { }
            }
        }
    }
}
