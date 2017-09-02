using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class IntValidator : PropertyValidator<int>
    {
        public override bool TryParse(string i_Source, out int o_Target)
        {
            return int.TryParse(i_Source, out o_Target);    
        }
    }
}