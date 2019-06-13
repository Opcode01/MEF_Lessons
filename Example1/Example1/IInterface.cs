using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public interface IInterface
    {
        string name { get; }
    }

    [Export(typeof(IInterface))]
    public class A : IInterface
    {
        public string name
        {
            get { return "Name 1"; }
        }
    }

    [Export(typeof(IInterface))]
    public class B : IInterface
    {
        public string name
        {
            get { return "Name 2"; }
        }
    }
}
