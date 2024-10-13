using Clqp.Exception;

namespace Clqp;

public class GlobalVariable
{
    private List<Variable> _variables = new();

    public GlobalVariable Add(Variable variable)
    {
        _variables.Add(variable);
        return this;
    }

    public GlobalVariable InsertRangeCommand(params Variable[] variables)
    {
        ArgumentNullException.ThrowIfNull(variables);

        if (variables.Length > 0)
            _variables.AddRange(variables);

        return this;
    }
    
    public GlobalVariable Work(ICluster<GlobalVariable> cluster)
    {
        cluster.WorkWith(this);
        return this;
    }

    public void Set(string name, string value)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(value);
        
        var variable = _variables.Find(v => v.Name == name);

        if (variable == null)
            throw new VariableNotFound(name);

        if (variable.Validator != null && !variable.Validator(value))
            throw new ValueInvalid(value, name);

        variable.Value = value;
    }
    
    public T GetAs<T>(string name)
    {
        var variable = _variables.Find(v => v.Name == name);

        if (variable == null)
            throw new VariableNotFound(name);

        return (T) Convert.ChangeType(variable.Value, typeof(T));
    }
    
    
}