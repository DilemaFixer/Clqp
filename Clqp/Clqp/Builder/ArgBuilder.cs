using Clqp.Exception;

namespace Clqp.Builder;

public class ArgBuilder
{
    private List<Parameter> _parameters = new();

    public ArgBuilder AddParameter(Parameter parameter)
    {
        _parameters.Add(parameter);
        return this;
    }

    public Arg Build()
    {
        if (_parameters.Count == 0)
            throw new BuildingException("ArgBuilder", "Arg require , but it is empty");
        
        return new Arg(_parameters);
    }
}