﻿using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;

namespace GrillBackend.Models.Meals
{
    public class Kebab : Food, IGrillable
    {
        public Kebab() { }
        public Kebab(string name, int amount, int weight) : base(name, amount, weight) { }
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
            return new Kebab(base.Name, base.Amount, Weight);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
