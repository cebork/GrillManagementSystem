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
        public void GrillFood()
        {
            IsOnGrill = true;
            while (IsOnGrill)
            {
                Thread.Sleep(1000);
                OnGrillTime += 1;
                if (OnGrillTime <= 10)
                {
                    DonenessLevel = DonenessLevel.notReady;
                }
                else if (OnGrillTime > 10 && OnGrillTime <= 20)
                {
                    DonenessLevel = DonenessLevel.ready;
                }
                else
                {
                    DonenessLevel = DonenessLevel.overCooked;
                }
                Console.WriteLine(Name + " " + OnGrillTime + " " + DonenessLevel);
            }
        }

        public void Feed()
        {
            if (Amount > 0)
            {
                Amount -= 0;
            }
            else
            {
                throw new NoFoodException("Nie ma już " + Name);
            }
        }
    }
}
