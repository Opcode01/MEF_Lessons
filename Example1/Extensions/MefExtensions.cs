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
        [ExportMetadata("Uppercase", "Y")]
        public class Class1 : IInterfaceWithInheritance
        {
            public string name
            {
                get { return "Coming from Inherited interface, Class 1"; }
            }
        }

        public class Class2 : IInterfaceWithInheritance
        {
            public string name
            {
                get { return "Coming from Inherited interface, Class 2"; }
            }
        }

        [Export(typeof(IInterface))]
        [ExportMetadata("Uppercase", "Y")]
        public class A : IInterface
        {
            public string name
            {
                get { return "Name 1"; }
            }
        }

        [Export(typeof(IInterface))]
        [ExportMetadata("Uppercase", "N")]
        public class B : IInterface
        {
            public string name
            {
                get { return "Name 2"; }
            }
        }

        [Export(typeof(IInterface))]
        [ExportMetadata("Uppercase", "Y")]
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
