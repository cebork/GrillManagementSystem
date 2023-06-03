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
        public Water(string name, int weight) : base(name, weight) { }
    }
}
