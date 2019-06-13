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
        [Export]
        string msg = "Hello MEF";

        [Import]
        string message;

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

            Console.WriteLine(program.message);
            Console.ReadLine();
        }
    }
}
