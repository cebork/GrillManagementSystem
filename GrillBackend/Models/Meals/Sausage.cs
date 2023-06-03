using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;

namespace GrillBackend.Models.Meals
{
    public class Sausage : Meal, IGrillable
    {
        public Sausage(string name, SpicyLevel spicyLevel, int weight, int price) : base(name, spicyLevel, weight, price) { }
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
    }
}
