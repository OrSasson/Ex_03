using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class IntParcer : PropertyParcer<int>
    {
        public override bool TryParce(string i_Source, out int o_Target)
        {
            return int.TryParse(i_Source, out o_Target);    
        }
    }
}
