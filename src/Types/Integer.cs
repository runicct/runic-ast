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
        internal static Integer _i8 = new Integer(true, 8);
        internal static Integer _i16 = new Integer(true, 16);
        internal static Integer _i32 = new Integer(true, 32);
        internal static Integer _i64 = new Integer(true, 64);
        internal static Integer _u8 = new Integer(false, 8);
        internal static Integer _u16 = new Integer(false, 16);
        internal static Integer _u32 = new Integer(false, 32);
        internal static Integer _u64 = new Integer(false, 64);
        public class Integer : Type
        {
            bool _signed;
            public bool Signed { get { return _signed; } }
            uint _bits;
            public uint Bits { get { return _bits; } }
            public override ulong SizeOf(uint pointerSize, uint packing, uint padding) { return _bits / 8; }
            public Integer(bool Signed, uint bits)
            {
                _signed = Signed;
                _bits = bits;
            }
            public override string ToString()
            {
                return (_signed ? "i" : "u") + _bits.ToString();
            }
#if NET6_0_OR_GREATER
            public override bool Equals(object? obj)
#else
            public override bool Equals(object obj)
#endif
            {
                if (obj == null) { return false; }
#if NET6_0_OR_GREATER
                Integer? integer = obj as Integer;
#else
                Integer integer = obj as Integer;
#endif
                if (integer == null) { return false; }
                return (integer.Signed == this.Signed) && (integer.Bits == this.Bits);
            }

            public override int GetHashCode() { return (int)(0x7F000000 + (Signed ? 0x00A00000 : 0x00B00000) + (Bits)); }
        }
    }
}
