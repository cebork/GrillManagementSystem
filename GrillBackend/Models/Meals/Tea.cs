using GrillBackend.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Models.Meals
{
    public class Tea : Meal, INotGrillable
    {
        public Tea() { }
        public Tea(string name, int amount) : base(name, amount) { }
    }
}
