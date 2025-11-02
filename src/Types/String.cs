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
        internal static String _utf8String = new String(CharEncoding.UTF8);
        internal static String _utf16String = new String(CharEncoding.UTF16);
        internal static String _utf32String = new String(CharEncoding.UTF32);
        public class String : Type
        {
            CharEncoding _encoding;
            public CharEncoding Encoding { get { return _encoding; } }
            public override ulong SizeOf(uint pointerSize, uint packing, uint padding)
            {
                return pointerSize;
            }
            public String(CharEncoding encoding) { _encoding = encoding; }
            public override string ToString()
            {
                return "string";
            }
#if NET6_0_OR_GREATER
            public override bool Equals(object? obj)
#else
            public override bool Equals(object obj)
#endif
            {
                if (obj == null) { return false; }
#if NET6_0_OR_GREATER
                String? str = obj as String;
#else
                String str = obj as String;
#endif
                if (str == null) { return false; }
                return str.Encoding == this.Encoding;
            }
            public override int GetHashCode() { return (int)(0x7F000000 + 0x00050000 + (int)this.Encoding); }
        }
    }
}
