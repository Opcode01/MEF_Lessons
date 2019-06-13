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

        [Import]
        string message;

        [Import]
        int integer;

        [Import]
        Func<double, double, double> result { get; set; }

        private void Compose()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(typeof(Extensions.MefExtensions).Assembly);
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Compose();

            Console.WriteLine(program.message);
            Console.WriteLine(program.integer);
            Console.WriteLine(program.result(1.3, 4.1));
            Console.ReadLine();
        }
    }
}
