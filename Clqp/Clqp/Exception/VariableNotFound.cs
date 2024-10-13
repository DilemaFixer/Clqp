namespace Clqp.Exception;

public class VariableNotFound : System.Exception
{
    public string VaribaleName { get;}

    public VariableNotFound(string variableName) : base("Variable with name " + variableName + " not found.")
    {
        VaribaleName = variableName;
    }
}