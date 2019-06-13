using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class MefExtensions
    {
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

        [Export(typeof(IInterface))]
        public class C : IInterface
        {
            public string name
            {
                get { return "Hello extensible 1"; }
            }
        }

        [Export(typeof(IInterface))]
        public class D : IInterface
        {
            public string name
            {
                get { return "Hello extensible 2"; }
            }
        }

        [Export(typeof(IInterface))]
        public class E : IInterface
        {
            public string name
            {
                get { return "Hello extensible 3"; }
            }
        }
    }
}
