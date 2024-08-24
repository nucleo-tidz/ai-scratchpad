using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai.scratchpad.UseCases.Summarise
{
    internal interface ISummary
    {
        Task Summarise(string text);
    }
}
