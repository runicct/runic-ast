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
    public abstract partial class Type
    {
        public class Pointer : Type
        {
            Type _targetType;
            public Type TargetType { get { return _targetType; } }
            public override ulong SizeOf(uint pointerSize, uint packing, uint padding) { return pointerSize; }
            public Pointer(Type TargetType)
            {
                _targetType = TargetType;
            }
            public override string ToString()
            {
                return _targetType.ToString() + "*";
            }
#if NET6_0_OR_GREATER
            public override bool Equals(object? obj)
#else
            public override bool Equals(object obj)
#endif
            {
                if (obj == null) { return false; }
#if NET6_0_OR_GREATER
                Pointer? ptr = obj as Pointer;
#else
                Pointer ptr = obj as Pointer;
#endif
                if (ptr == null) { return false; }
                return ptr._targetType.Equals(this._targetType);
            }
        }
    }
}
