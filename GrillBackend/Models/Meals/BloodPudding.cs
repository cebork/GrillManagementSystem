using GrillBackend.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GrillBackend.Models.Enums;
using GrillBackend.Exceptions;
namespace GrillBackend.Models.Meals
{
    
    public class BloodPudding : Meal, IGrillable
    {
        public int Weight { get; set; }
        public BloodPudding() { }
        public BloodPudding(string name, int amount, int weight) : base(name, amount) 
        {
            Weight = weight;
        }

        public void Feed()
        {
            if (Amount > 0)
            {
                Amount -= 1;
            }
            else
            {
                throw new NoFoodException("Nie ma już " + Name);
            }
        }

        public object Clone()
        {
            return new BloodPudding(base.Name, base.Amount, Weight);
        }
    }
}
