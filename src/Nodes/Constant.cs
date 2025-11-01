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
            public abstract class Constant : Expression
            {
#if NET6_0_OR_GREATER

                public Constant(int startLine, int startColumn, int endLine, int endColumn, string? file) : base(startLine, startColumn, endLine, endColumn, file) { }
#else
                public Constant(int startLine, int startColumn, int endLine, int endColumn, string file) : base(startLine, startColumn, endLine, endColumn, file) { }
#endif
                public Constant() : base() { }
                public class I8 : Constant
                {
                    sbyte _value;
                    public sbyte Value { get { return _value; } }
                    public override Type Type { get { return Type._i8; } }
#if NET6_0_OR_GREATER
                    public I8(int startLine, int startColumn, int endLine, int endColumn, string? file, sbyte value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#else
                    public I8(int startLine, int startColumn, int endLine, int endColumn, string file, sbyte value) : base(startLine, startColumn, endLine, endColumn, file) {  _value = value; }
#endif
                    public I8(sbyte value) : this(-1, -1, -1, -1, null, value) { }
                }
                public class I16 : Constant
                {
                    short _value;
                    public short Value { get { return _value; } }
                    public override Type Type { get { return Type._i16; } }
#if NET6_0_OR_GREATER
                    public I16(int startLine, int startColumn, int endLine, int endColumn, string? file, short value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#else
                    public I16(int startLine, int startColumn, int endLine, int endColumn, string file, short value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#endif
                    public I16(short value) : this(-1, -1, -1, -1, null, value) { }
                }
                public class I32 : Constant
                {
                    int _value;
                    public int Value { get { return _value; } }
                    public override Type Type { get { return Type._i32; } }
#if NET6_0_OR_GREATER
                    public I32(int startLine, int startColumn, int endLine, int endColumn, string? file, int value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#else
                    public I32(int startLine, int startColumn, int endLine, int endColumn, string file, int value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#endif
                    public I32(int value) : this(-1, -1, -1, -1, null, value) { }
                }
                public class I64 : Constant
                {
                    long _value;
                    public long Value { get { return _value; } }
                    public override Type Type { get { return Type._i64; } }
#if NET6_0_OR_GREATER
                    public I64(int startLine, int startColumn, int endLine, int endColumn, string? file, long value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#else
                    public I64(int startLine, int startColumn, int endLine, int endColumn, string file, long value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#endif
                    public I64(long value) : this(-1, -1, -1, -1, null, value) { }
                }
                public class F32 : Constant
                {
                    float _value;
                    public float Value { get { return _value; } }
                    public override Type Type { get { return Type._f32; } }
#if NET6_0_OR_GREATER
                    public F32(int startLine, int startColumn, int endLine, int endColumn, string? file, float value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#else
                    public F32(int startLine, int startColumn, int endLine, int endColumn, string file, float value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#endif
                    public F32(float value) : this(-1, -1, -1, -1, null, value) { }
                }
                public class F64 : Constant
                {
                    double _value;
                    public double Value { get { return _value; } }
                    public override Type Type { get { return Type._f64; } }
#if NET6_0_OR_GREATER
                    public F64(int startLine, int startColumn, int endLine, int endColumn, string? file, double value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#else
                    public F64(int startLine, int startColumn, int endLine, int endColumn, string file, double value) : base(startLine, startColumn, endLine, endColumn, file) { _value = value; }
#endif
                    public F64(double value) : this(-1, -1, -1, -1, null, value) { }
                }
                public class Null : Constant
                {
                    public override Type Type { get { return Type._nullptr; } }
#if NET6_0_OR_GREATER
                    public Null(int startLine, int startColumn, int endLine, int endColumn, string? file) : base(startLine, startColumn, endLine, endColumn, file) { }
#else
                    public Null(int startLine, int startColumn, int endLine, int endColumn, string file) : base(startLine, startColumn, endLine, endColumn, file) { }
#endif
                    public Null() : base() { }
                }
            }
        }
    }
}
