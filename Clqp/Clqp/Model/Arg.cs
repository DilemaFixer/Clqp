using Clqp.Builder;
using Clqp.Exception;

namespace Clqp;

public class Arg
{
    private List<Parameter> _parameters;

    public Arg(List<Parameter> parameters)
    {
        _parameters = parameters;
    }
    
    public static ArgBuilder Builder()
    {
        return new ArgBuilder();
    }
    
    public (string parameterName, string value)[] ValidateInputParameters((string parameterName, string value)[] parameters)
    {
        var result = new List<(string parameterName, string value)>();

        foreach (var param in _parameters)
        {
            var matchingParam = parameters.FirstOrDefault(p => p.parameterName == param.Name);

            if (matchingParam != default)
            {
                if (param != null && param.Validator(matchingParam.value))
                {
                    result.Add((param.Name, matchingParam.value));
                }
                else
                {
                    throw new ValueInvalid(matchingParam.value, param.Name);
                }
            }
            else
            {
                if (param.Required)
                {
                    throw new ValueInvalid(param.DefaultValue, param.Name);
                }
                else
                {
                    result.Add((param.Name, param.DefaultValue ?? null));
                }
            }
        }

        return result.ToArray();
    }

}