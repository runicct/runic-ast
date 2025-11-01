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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Runic.AST
{
    public abstract partial class Node
    {
        public abstract partial class Expression : Node
        {
            public abstract class Decrement : Expression
            {
#if NET6_0_OR_GREATER
                public Decrement(int startLine, int startColumn, int endLine, int endColumn, string? file) : base(startLine, startColumn, endLine, endColumn, file) { }
#else
                public Decrement(int startLine, int startColumn, int endLine, int endColumn, string file) : base(startLine, startColumn, endLine, endColumn, file) { }
#endif
                public Decrement() : base() { }
                public abstract class Prefix : Decrement
                {
#if NET6_0_OR_GREATER
                    public Prefix(int startLine, int startColumn, int endLine, int endColumn, string? file) : base(startLine, startColumn, endLine, endColumn, file) { }
#else
                    public Prefix(int startLine, int startColumn, int endLine, int endColumn, string file) : base(startLine, startColumn, endLine, endColumn, file) { }
#endif
                    public Prefix() : base() { }
                    public class Variable : Prefix
                    {
                        AST.Variable _target;
                        public AST.Variable Target { get { return _target; } }
                        public override Type Type { get { return _target.Type; } }
#if NET6_0_OR_GREATER
                        public Variable(int startLine, int startColumn, int endLine, int endColumn, string? file, AST.Variable target) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Variable(int startLine, int startColumn, int endLine, int endColumn, string file, AST.Variable target) : base(startLine,startColumn, endLine, endColumn, file)
#endif
                        {
                            _target = target;
                        }
                        public Variable(AST.Variable target) : this(-1, -1, -1, -1, null, target) { }
                    }
                    public class Dereference : Prefix
                    {
                        Type _type;
                        public override Type Type { get { return _type; } }
                        AST.Node.Expression _address;
                        public AST.Node.Expression Address { get { return _address; } }
#if NET6_0_OR_GREATER
                        public Dereference(int startLine, int startColumn, int endLine, int endColumn, string? file, Expression address) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Dereference(int startLine, int startColumn, int endLine, int endColumn, string file, Expression address) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                        {
#if NET6_0_OR_GREATER
                            Type.Pointer? pointerType = address.Type as Type.Pointer;
#else
                            Type.Pointer pointerType = address.Type as Type.Pointer;
#endif
                            if (pointerType == null)
                            {
                                throw new Exception("Cannot dereference a non-pointer type");
                            }
                            _type = pointerType.TargetType;
                            _address = address;
                        }
                        public Dereference(Expression address) : this(-1, -1, -1, -1, null, address) { }

                    }
                    public class Indexing : Prefix
                    {
                        Type _type;
                        public override Type Type { get { return _type; } }
                        AST.Node.Expression _target;
                        public AST.Node.Expression Target { get { return _target; } }
                        AST.Node.Expression _index;
                        public AST.Node.Expression Index { get { return _index; } }
#if NET6_0_OR_GREATER
                        public Indexing(int startLine, int startColumn, int endLine, int endColumn, string? file, Expression target, Expression index) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Indexing(int startLine, int startColumn, int endLine, int endColumn, string file, Expression target, Expression index) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                        {
#if NET6_0_OR_GREATER
                            Type.Pointer? pointerType = target.Type as Type.Pointer;
#else
                            Type.Pointer pointerType = target.Type as Type.Pointer;
#endif
                            if (pointerType == null)
                            {
                                throw new Exception("Cannot dereference a non-pointer type");
                            }
                            _type = pointerType.TargetType;
                            _target = target;
                            _index = index;
                        }

                        public Indexing(Expression target, Expression index) : this(-1, -1, -1, -1, null, target, index) { }
                    }
                    public class Member : Prefix
                    {
                        Type.StructOrUnion.Field[] _fields;
                        public Type.StructOrUnion.Field[] Fields { get { return _fields; } }
                        public override Type Type { get { return _fields[_fields.Length - 1].Type; } }
                        AST.Variable _target;
                        public AST.Variable Target { get { return _target; } }
#if NET6_0_OR_GREATER
                        public Member(int startLine, int startColumn, int endLine, int endColumn, string? file, AST.Variable target, Type.StructOrUnion.Field[] field) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Member(int startLine, int startColumn, int endLine, int endColumn, string file, AST.Variable target, Type.StructOrUnion.Field[] field) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                        {
                            _target = target;
                            _fields = field;
                        }
                    }
                }
                public abstract class Postfix : Decrement
                {
#if NET6_0_OR_GREATER
                    public Postfix(int startLine, int startColumn, int endLine, int endColumn, string? file) : base(startLine, startColumn, endLine, endColumn, file) { }
#else
                    public Postfix(int startLine, int startColumn, int endLine, int endColumn, string file) : base(startLine, startColumn, endLine, endColumn, file) { }
#endif
                    public Postfix() : base() { }
                    public class Variable : Postfix
                    {
                        AST.Variable _target;
                        public AST.Variable Target { get { return _target; } }
                        public override Type Type { get { return _target.Type; } }
#if NET6_0_OR_GREATER
                        public Variable(int startLine, int startColumn, int endLine, int endColumn, string? file, AST.Variable target) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Variable(int startLine, int startColumn, int endLine, int endColumn, string file,AST.Variable target) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                        {
                            _target = target;
                        }
                        public Variable(AST.Variable target) : this(-1, -1, -1, -1, null, target) { }
                    }
                    public class Dereference : Postfix
                    {
                        Type _type;
                        public override Type Type { get { return _type; } }
                        AST.Node.Expression _address;
                        public AST.Node.Expression Address { get { return _address; } }
#if NET6_0_OR_GREATER
                        public Dereference(int startLine, int startColumn, int endLine, int endColumn, string? file, Expression address) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Dereference(int startLine, int startColumn, int endLine, int endColumn, string file,Expression address) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                        {
#if NET6_0_OR_GREATER
                            Type.Pointer? pointerType = address.Type as Type.Pointer;
#else
                            Type.Pointer pointerType = address.Type as Type.Pointer;
#endif
                            if (pointerType == null)
                            {
                                throw new Exception("Cannot dereference a non-pointer type");
                            }
                            _type = pointerType.TargetType;
                            _address = address;

                        }
                        public Dereference(Expression address) : this(-1, -1, -1, -1, null, address) { }
                    }


                    public class Indexing : Postfix
                    {
                        Type _type;
                        public override Type Type { get { return _type; } }
                        AST.Node.Expression _target;
                        public AST.Node.Expression Target { get { return _target; } }
                        AST.Node.Expression _index;
                        public AST.Node.Expression Index { get { return _index; } }
#if NET6_0_OR_GREATER
                        public Indexing(int startLine, int startColumn, int endLine, int endColumn, string? file, Expression target, Expression index) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Indexing(int startLine, int startColumn, int endLine, int endColumn, string file, Expression target, Expression index) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                        {
#if NET6_0_OR_GREATER
                            Type.Pointer? pointerType = target.Type as Type.Pointer;
#else
                            Type.Pointer pointerType = target.Type as Type.Pointer;
#endif
                            if (pointerType == null)
                            {
                                throw new Exception("Cannot dereference a non-pointer type");
                            }
                            _type = pointerType.TargetType;
                            _target = target;
                            _index = index;
                        }
                        public Indexing(Expression target, Expression index) : this(-1, -1, -1, -1, null, target, index) { }
                    }
                    public class Member : Postfix
                    {
                        Type.StructOrUnion.Field[] _fields;
                        public Type.StructOrUnion.Field[] Fields { get { return _fields; } }
                        public override Type Type { get { return _fields[_fields.Length - 1].Type; } }
                        AST.Variable _target;
                        public AST.Variable Target { get { return _target; } }
#if NET6_0_OR_GREATER
                        public Member(int startLine, int startColumn, int endLine, int endColumn, string? file, AST.Variable target, Type.StructOrUnion.Field[] field) : base(startLine, startColumn, endLine, endColumn, file)
#else
                        public Member(int startLine, int startColumn, int endLine, int endColumn, string file, AST.Variable target, Type.StructOrUnion.Field[] field) : base(startLine, startColumn, endLine, endColumn, file)
#endif
                        {
                            _target = target;
                            _fields = field;
                        }
                        public Member(AST.Variable target, Type.StructOrUnion.Field[] field) : this(-1, -1, -1, -1, null, target, field) { }
                    }
                }
            }
        }
    }
}
