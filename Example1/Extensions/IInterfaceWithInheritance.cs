using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{

    /// <summary>
    /// Any class that implements this interface will be exported via MEF without having to
    /// explicitly/concretely be dec
    /// </summary>
    [InheritedExport]
    public interface IInterfaceWithInheritance
    {
        string name { get; }
    }
}
