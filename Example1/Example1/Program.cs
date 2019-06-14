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

    class Program
    {

        #region ImportMany

        //Lazy indicates that the objects will not be instantiated until they are actually needed
        [ImportMany(typeof(IInterface))]
        List<Lazy<IInterface, IInterfaceMetadata>> objList;
        
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

            #region Coding with Interface

            #endregion

            foreach (var obj in program.objList)
            {
                if (obj.Metadata.Uppercase.Equals("Y"))
                    Console.WriteLine(obj.Value.name.ToUpper());
                else
                    Console.WriteLine(obj.Value.name);


            }
            Console.ReadLine();
        }
    }
}
