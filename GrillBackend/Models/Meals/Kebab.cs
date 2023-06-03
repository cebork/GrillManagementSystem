using GrillBackend.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Models.Meals
{
    public class Kebab : Meal, IGrillable
    {
        public int Weight { get; set; }

        public Kebab() { }
        public Kebab(string name, int amount, int weight) : base(name, amount)
        {
            Weight = weight;
        }
        public void GrillFood()
        {
            throw new NotImplementedException();
        }
    }
}
