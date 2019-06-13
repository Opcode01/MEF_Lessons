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
    class Program
    {

        #region ImportMany

        //Lazy indicates that the objects will not be instantiated until they are actually needed
        [ImportMany(typeof(IInterface))]
        List<Lazy<IInterface>> objList;
        
        #endregion

        private void Compose()
        {
            //AssemblyCatalog catalog = new AssemblyCatalog(typeof(IInterface).Assembly);
            DirectoryCatalog catalog = new DirectoryCatalog(".");

            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Compose();

            #region Coding with Interface

            #endregion

            foreach(var obj in program.objList)
                Console.WriteLine(obj.Value.name);

            Console.ReadLine();
        }
    }
}
