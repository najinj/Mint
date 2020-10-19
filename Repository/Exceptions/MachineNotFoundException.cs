using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Exceptions
{
    public class MachineNotFoundException : Exception
    {
        public MachineNotFoundException()
        {

        }

        public MachineNotFoundException(string msg) : base(msg)
        {

        }
    }
}
