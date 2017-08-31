using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class FloatParcer : PropertyParcer<float>
    {
        public override bool TryParce(string i_Source, out float o_Target)
        {
            return float.TryParse(i_Source, out o_Target);
        }
    }
}
