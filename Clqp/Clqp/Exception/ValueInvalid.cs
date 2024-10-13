namespace Clqp.Exception;

public class ValueInvalid : System.Exception
{
    public string VariableName { get; }
    public string Value { get; }

    public ValueInvalid(string value, string variableName) : base("Try set invalid value " + value + " to variable " +
                                                                  variableName)
    {
        Value = value;
        VariableName = variableName;
    }
}