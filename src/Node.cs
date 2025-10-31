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
        int _startLine;
        public int StartLine { get { return _startLine; } }
        int _startColumn;
        public int StartColumn { get { return _startColumn; } }
        int _endLine;
        public int EndLine { get { return _endLine; } }
        int _endColumn;
        public int EndColumn { get { return _endColumn; } }
#if NET6_0_OR_GREATER
        string? _file;
        public string? File { get { return _file; } }
#else
        string _file;
        public string File { get { return _file; } }
#endif
#if NET6_0_OR_GREATER
        public Node(int startLine, int startColumn, int endLine, int endColumn, string? file)
#else
        public Node(int startLine, int startColumn, int endLine, int endColumn, string file)
#endif
        {
            _startLine = startLine;
            _startColumn = startColumn;
            _endLine = endLine;
            _endColumn = endColumn;
        }
        public Node()
        {
            _startLine = -1;
            _startColumn = -1;
            _endLine = -1;
            _endColumn = -1;
            _file = null;
        }
    }
}
