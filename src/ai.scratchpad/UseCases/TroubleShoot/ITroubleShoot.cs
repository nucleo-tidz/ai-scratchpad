using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai.scratchpad.UseCases
{
    internal interface ITroubleShoot
    {
        Task Start(string prompt);
    }
}
