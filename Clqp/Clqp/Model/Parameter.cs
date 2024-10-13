using Clqp.Builder;

namespace Clqp;

public class Parameter
{
    public Parameter(string name, bool required, string defaultValue, Func<string, bool> validator)
    {
        Name = name;
        Required = required;
        DefaultValue = defaultValue;
        Validator = validator;
    }

    public string Name { get; }
    public bool Required { get; }
    public string DefaultValue { get; }
    public Func<string , bool> Validator { get; }

    public static ParameterBuilder Builder(string name) => new(name);
}