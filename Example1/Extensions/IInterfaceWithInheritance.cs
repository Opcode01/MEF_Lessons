using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    [InheritedExport]
    public interface IInterfaceWithInheritance
    {
        string name { get; }
    }
}
