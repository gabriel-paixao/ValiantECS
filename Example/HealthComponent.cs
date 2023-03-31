using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValiantECS.Example
{
    public struct HealthComponent
    {
        public int Current { get; set; }
        public int Max { get; set; }
    }
}
