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
        [Export]
        public double GetResult(double a, double b)
        {
            return a + b;
        }

        [Export]
        public int GetInteger
        {
            get { return 100; }
        }

        [Export]
        string msg = "Hello MEF";
    }
}
