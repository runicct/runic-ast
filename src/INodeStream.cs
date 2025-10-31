using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runic.AST
{
    public interface INodeStream
    {
        public AST.Node? ReadNextNode();
    }
}
