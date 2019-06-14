using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Extensions;

namespace Example
{
    [Export(typeof(IInterface))]
    class MyClass : IInterface
    {
        public string name
        {
            get { return "The power of aggregate";  }
        }
        
    }

    #region PartCreationPolicy

    [Export, PartCreationPolicy(CreationPolicy.Shared)] //Automatically implements singleton design pattern
    class PartForShared { public string TestMessage { get; set; } }

    [Export, PartCreationPolicy(CreationPolicy.NonShared)] //Creates a new instance every time
    class PartForNonShared { public string TestMessage { get; set; } }

    [Export, PartCreationPolicy(CreationPolicy.Any)] //Import decides what it needs
    class PartForAny { public string TestMessage { get; set; } }
    
    #endregion

    class Program
    {
        #region CreationPolicy

        [Import]
        PartForShared sharedObj1;

        [Import]
        PartForShared sharedObj2;

        [Import]
        PartForNonShared nonSharedObj1;

        [Import]
        PartForNonShared nonSharedObj2;

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        PartForAny anyObj1;

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        PartForAny anyObj2;

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        PartForAny anyObj3;

        #endregion
        #region ImportMany

        //Lazy indicates that the objects will not be instantiated until they are actually needed
        [ImportMany(typeof(IInterface))]
        List<Lazy<IInterface, IInterfaceMetadata>> objList;

        [ImportMany(typeof(IInterface))]
        List<Lazy<IInterface>> listOfObjectsWOM;

        [ImportMany(typeof(IInterfaceWithInheritance))]
        List<Lazy<IInterfaceWithInheritance>> inheritedObjs;
        
        #endregion

        private void Compose()
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(Program).Assembly);
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(".");

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assemblyCatalog);
            catalog.Catalogs.Add(directoryCatalog);

            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Compose();

            #region CreationPolicyImplementation

            //Shared Policy
            Console.WriteLine("----Shared Policy----");
            program.sharedObj1.TestMessage = "Test Message 1";
            Console.WriteLine("obj1 gets singleton instance: " + program.sharedObj1.TestMessage);
            Console.WriteLine("obj2 gets singleton instance: " + program.sharedObj2.TestMessage);

            //NonShared Policy
            Console.WriteLine("----NonShared Policy----");
            program.nonSharedObj1.TestMessage = "Test Message A";
            Console.WriteLine("obj1 gets new instance: " + program.nonSharedObj1.TestMessage);
            Console.WriteLine("obj2 gets new instance: " + program.nonSharedObj2.TestMessage);

            program.nonSharedObj2.TestMessage = "Test Message B";

            Console.WriteLine("obj1 gets has same instance: " + program.nonSharedObj1.TestMessage);
            Console.WriteLine("obj2 gets has same instance: " + program.nonSharedObj2.TestMessage);

            Console.WriteLine("----Any Policy----");
            program.anyObj1.TestMessage = "Test Message for any policy";

            Console.WriteLine("obj1 will get singleton instance: " + program.anyObj1.TestMessage);
            Console.WriteLine("obj2 will also get singleton instance " + program.anyObj2.TestMessage);
            Console.WriteLine("obj3 will get a new instance " + program.anyObj3.TestMessage);

            program.anyObj3.TestMessage = "new obj message";

            Console.WriteLine("obj1 will get singleton instance " + program.anyObj1.TestMessage);
            Console.WriteLine("obj2 will use singleton instance " + program.anyObj2.TestMessage);
            Console.WriteLine("obj3 will use the new instance " + program.anyObj3.TestMessage);



            #endregion

            #region Coding with Interface

            //foreach (var obj in program.objList)
            //{
            //    if (obj.Metadata.Uppercase.Equals("Y"))
            //        Console.WriteLine(obj.Value.name.ToUpper());
            //    else
            //        Console.WriteLine(obj.Value.name);
            //}

            //Console.WriteLine("-------------------");
            //foreach(var obj in program.inheritedObjs)
            //{
            //    Console.WriteLine(obj.Value.name);
            //}

            #endregion

            Console.ReadLine();
        }
    }
}
