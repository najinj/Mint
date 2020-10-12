﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mint.Repository.Exceptions
{
    public class MachineProductionNotFoundException : Exception
    {
        public MachineProductionNotFoundException()
        {
        }

        public MachineProductionNotFoundException(string msg)
            : base(msg)
        {

        }
    }
}
