using Clqp.Builder;

namespace Clqp;

public class Variable
{
    public Variable(string name, string description, string[] aliases, string value, Func<string, bool> validator, string defaultValue)
    {
        Name = name;
        Description = description;
        Aliases = aliases;
        Value = value;
        Validator = validator;
        DefaultValue = defaultValue;
    }

    public string Name { get; }
    public string Description { get; }
    public string[] Aliases { get; }
    public string Value { get; set; }
    public string DefaultValue { get; }
    public Func<string, bool> Validator { get; }

    public static VariableBuilder Build(string name) => new VariableBuilder(name);
}