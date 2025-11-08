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
            public class Indexing : Expression
            {
                Expression _address;
                public Expression Address { get { return _address; } }
                Expression _index;
                public Expression Index { get { return _index; } }
                Type _type;
                public override Type Type { get { return _type; } }
#if NET6_0_OR_GREATER
                public Indexing(int startLine, int startColumn, int endLine, int endColumn, string? file, Expression address, Expression index) : base(startLine, startColumn, endLine, endColumn, file)
#else
                public Indexing(int startLine, int startColumn, int endLine, int endColumn, string file, Expression address, Expression index) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                {
                    _address = address;
                    _index = index;
#if NET6_0_OR_GREATER
                    Type.Pointer? pointerType = address.Type as Type.Pointer;
#else
                    Type.Pointer pointerType = address.Type as Type.Pointer;
#endif
                    if (pointerType == null)
                    {
                        // Special case for indexing a string
#if NET6_0_OR_GREATER
                        Type.String? stringType = address.Type as Type.String;
#else
                        Type.String stringType = address.Type as Type.String;
#endif
                        if (stringType != null)
                        {
                            switch (stringType.Encoding)
                            {
                                case Type.CharEncoding.UTF8: _type = Type.Char._utf8Char; break;
                                case Type.CharEncoding.UTF16: _type = Type.Char._utf16Char; break;
                                case Type.CharEncoding.UTF32: _type = Type.Char._utf32Char; break;
                                default: _type = Type.Char._utf8Char; break;
                            }
                        }
                        else
                        {
                            throw new Exception("Cannot index a non-pointer type");
                        }
                    }
                    else
                    {
                        _type = pointerType.TargetType;
                    }
                }
                public Indexing(Expression address, Expression index) : this(-1, -1, -1, -1, null, address, index) { }
            }
        }
    }
}
