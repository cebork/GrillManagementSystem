﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;

namespace GrillBackend.Models.Meals
{
    public class Sausage : Food, IGrillable
    {
        public Sausage() { }
        public Sausage(string name, int amount, int weight) : base(name, amount, weight) { }
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
            return new Sausage(base.Name, base.Amount, Weight);
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
