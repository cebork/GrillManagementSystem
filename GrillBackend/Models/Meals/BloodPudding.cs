using GrillBackend.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Models.Meals
{
    public class BloodPudding : Meal, IGrillable
    {
        public BloodPudding(string name, int weight) : base(name, weight) { }
        public void GrillFood()
        {
            throw new NotImplementedException();
        }
    }
}
