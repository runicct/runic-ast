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
        internal static FloatingPoint _f32 = new FloatingPoint(32);
        internal static FloatingPoint _f64 = new FloatingPoint(64);
        public class FloatingPoint : Type
        {
            uint _bits;
            public uint Bits { get { return _bits; } }
            public override ulong SizeOf(uint pointerSize, uint packing, uint padding) { return _bits / 8; }
            public FloatingPoint(uint bits)
            {
                _bits = bits;
            }
            public override string ToString()
            {
                return ("f") + _bits.ToString();
            }
#if NET6_0_OR_GREATER
            public override bool Equals(object? obj)
#else
            public override bool Equals(object obj)
#endif
            {
                if (obj == null) { return false; }
#if NET6_0_OR_GREATER
                FloatingPoint? fp = obj as FloatingPoint;
#else
                FloatingPoint fp = obj as FloatingPoint;
#endif
                if (fp == null) { return false; }
                return (fp.Bits == this.Bits);
            }

            public override int GetHashCode() { return (int)(0x7F000000 + 0x00900000 + (Bits)) ; }
        }
    }
}
