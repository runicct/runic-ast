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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Runic.AST
{
    public abstract partial class Type
    {
        public abstract class StructOrUnion
        {
            public class Field
            {
                Type _type;
                public Type Type { get { return _type; } }
                StructOrUnion _parent;
                bool _indexSet = false;
                uint _index;
                public uint Index
                {
                    get
                    {
                        lock (this)
                        {
                            if (!_indexSet)
                            {
                                for (int n = 0; n < _parent.Fields.Length; n++)
                                {
                                    if (this == _parent.Fields[n])
                                    {
                                        _index = (uint)n;
                                        _indexSet = true;
                                        return _index;
                                    }
                                }
                                throw new Exception("Inconsistent field. The field parent struct doesn't have this field in its field list");
                            }
                            return _index;
                        }
                    }
                }
                bool _offsetSet = false;
                ulong _offset;
                public virtual ulong Offset(uint pointerSize, uint packing, uint padding)
                {
                    lock (this)
                    {
                        if (!_offsetSet)
                        {
                            uint index = Index;
                            if (index == 0) { return 0; }
                            Field previousField = _parent._fields[index - 1];
                            _offset = previousField.Offset(pointerSize, packing, padding) + previousField.Type.SizeOf(pointerSize, packing, padding);
                        }
                        return _offset;
                    }
                }
                public Field(StructOrUnion parent, Type type)
                {
                    _parent = parent;
                    _type = type;
                }
            }

            Field[] _fields;
            public Field[] Fields { get { return _fields; } }
            public StructOrUnion(Field[] fields)
            {
                _fields = fields;
            }
        }
    }
}
