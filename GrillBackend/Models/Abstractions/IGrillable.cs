﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Models.Abstractions
{
    public interface IGrillable : ICloneable
    {
        public abstract void Feed();
    }
}
