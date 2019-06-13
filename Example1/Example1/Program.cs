using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Example1
{
    class Program
    {

        #region ImportMany

        #endregion

        private void Compose()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(typeof(Program).Assembly);
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Compose();

        #region Coding with Interface

        #endregion

            Console.ReadLine();
        }
    }
}
