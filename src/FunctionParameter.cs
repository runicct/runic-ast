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
    public abstract partial class Variable
    {
        public class FunctionParameter : Variable
        {
            Type _type;
            public override Type Type { get { return _type; } }
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
                            for (int n = 0; n < _parent.Parameters.Length; n++)
                            {
                                if (this == _parent.Parameters[n])
                                {
                                    _index = (uint)n;
                                    _indexSet = true;
                                    return _index;
                                }
                            }
                            throw new Exception("Inconsistent function parameter. The parameter parent function doesn't have this parameter in its parameter list");
                        }
                        return _index;
                    }
                } 
            }
            Node.Function _parent;
            public FunctionParameter(Node.Function parent, Type type)
            {
                _parent = parent;
                _type = type;
            }
        }
    }
}
