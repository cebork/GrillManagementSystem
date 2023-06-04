using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;

namespace GrillBackend.Models.Meals
{
    public class Sausage : Meal, IGrillable
    {
        public int Weight { get; set; }
        public Sausage() { }
        public Sausage(string name, int amount, int weight) : base(name, amount)
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
