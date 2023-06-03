    using GrillBackend.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Models.Meals
{
    public class Water : Meal, INotGrillable
    {
        public Water() { }
        public Water(string name, int amount) : base(name, amount) { }
    }
}
