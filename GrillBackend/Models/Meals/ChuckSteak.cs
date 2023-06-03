using GrillBackend.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GrillBackend.Models.Meals
{
    public class ChuckSteak : Meal, IGrillable
    {
        public int Weight { get; set; }
        public ChuckSteak() { }
        public ChuckSteak(string name, int amount, int weight) : base(name, amount)
        {
            Weight = weight;
        }
        public void GrillFood()
        {
            throw new NotImplementedException();
        }
    }
}
