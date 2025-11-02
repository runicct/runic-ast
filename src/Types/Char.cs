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
        public enum CharEncoding
        {
            UTF8,
            UTF16,
            UTF32
        }

        internal static Char _utf8Char = new Char(CharEncoding.UTF8);
        internal static Char _utf16Char = new Char(CharEncoding.UTF16);
        internal static Char _utf32Char = new Char(CharEncoding.UTF32);
        public class Char : Type
        {

            CharEncoding _encoding;
            public CharEncoding Encoding { get { return _encoding; } }
            public override ulong SizeOf(uint pointerSize, uint packing, uint padding)
            {
                switch (_encoding)
                {
                    case CharEncoding.UTF8:
                        return 1;
                    case CharEncoding.UTF16:
                        return 2;
                    case CharEncoding.UTF32:
                        return 4;
                }
                return 1;
            }
            public Char(CharEncoding encoding) { _encoding = encoding; }
            public override string ToString()
            {
                return "char";
            }
#if NET6_0_OR_GREATER
            public override bool Equals(object? obj)
#else
            public override bool Equals(object obj)
#endif
            {
                if (obj == null) { return false; }
#if NET6_0_OR_GREATER
                Char? str = obj as Char;
#else
                Char str = obj as Char;
#endif
                if (str == null) { return false; }
                return str.Encoding == this.Encoding;
            }
            public override int GetHashCode() { return (int)(0x7F000000 + 0x00060000 + (int)this.Encoding); }
        }
    }
}
