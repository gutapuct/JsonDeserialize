﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDeserialize
{
    public interface IMyObjectSerializer
    {
        string Serialize(IMyObject myObject);
    }
}

