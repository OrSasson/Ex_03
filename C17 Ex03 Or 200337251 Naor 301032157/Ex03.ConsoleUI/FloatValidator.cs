namespace Ex03.ConsoleUI
{
    public class FloatValidator : PropertyValidator<float>
    {
        public override bool TryParse(string i_Source, out float o_Target)
        {
            return float.TryParse(i_Source, out o_Target);
        }
    }
}