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
        public class FunctionPointer : Pointer
        {
            Type _returnType;
            public Type ReturnType { get { return _returnType; } }
            Type[] _parameterTypes;
            public Type[] ParameterType { get { return _parameterTypes; } }
            public override ulong SizeOf(uint pointerSize, uint packing, uint padding) { return pointerSize; }
            public FunctionPointer(Type returnType, Type[] parameterTypes) : base(_invalid)
            {
                _returnType = returnType;
                _parameterTypes = parameterTypes;
            }
#if NET6_0_OR_GREATER
            public override bool Equals(object? obj)
#else
            public override bool Equals(object obj)
#endif
            {
                if (obj == null) { return false; }
#if NET6_0_OR_GREATER
                FunctionPointer? ptr = obj as FunctionPointer;
#else
                FunctionPointer ptr = obj as FunctionPointer;
#endif
                if (ptr == null) { return false; }
                if (ptr._parameterTypes.Length != this._parameterTypes.Length) { return false; }
                if (!ptr._returnType.Equals(this._returnType)) { return false; }
                for (int n = 0; n < ptr._parameterTypes.Length; n++)
                {
                    if (!ptr._parameterTypes[n].Equals(this._parameterTypes[n])) { return false; }
                }
                return true;
            }
            public override string ToString()
            {
                return "<function>*";
            }
        }
    }
}
