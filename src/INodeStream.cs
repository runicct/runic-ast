using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runic.AST
{
    public interface INodeStream
    {
#if NET6_0_OR_GREATER
        public AST.Node? ReadNextNode();
#else
        AST.Node ReadNextNode();
#endif
    }
}
