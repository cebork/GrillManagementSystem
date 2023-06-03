﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrillBackend.Models.Enums;
namespace GrillBackend.Models.Abstractions
{
    public abstract class Meal
    {
        public string? Name { get; set; }
        public int Amount { get; set; }
        public int OnGrillTime { get; set; }
        public bool IsOnGrill { get; set; }
        public DonenessLevel DonenessLevel { get; set; }
        
        public Meal() { }

        public Meal(string name, int amount)
        {
            Name = name;
            OnGrillTime = 0;
            IsOnGrill = false;
            DonenessLevel = DonenessLevel.notReady;
            Amount = amount;
        }


    }
}
