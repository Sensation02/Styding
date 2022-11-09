using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer_yield__індекксатори_ітератори_
{
    internal class Car
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return Name + " " + Number;
        }
    }
}
