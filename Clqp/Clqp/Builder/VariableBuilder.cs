namespace Clqp.Builder;

public class VariableBuilder
{
    private string _name;
    private string _description = "emmpety";
    private string[] _aliases = {};
    private string _value;
    private string _defaultValue = string.Empty;
    private Func<string, bool> _validator;

    public VariableBuilder(string name)
    {
        _name = name;
    }
    
    public VariableBuilder Description(string description)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(description);
        _description = description;
        return this;
    }
    
    public VariableBuilder Aliases(params string[] aliases)
    {
        ArgumentNullException.ThrowIfNull(aliases);
        _aliases = aliases;
        return this;
    }

    public VariableBuilder DefaultValue(string defaultValue)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(defaultValue);
        _defaultValue = defaultValue;
        return this;
    }
    
    public VariableBuilder Validator(Func<string, bool> validator)
    {
        ArgumentNullException.ThrowIfNull(validator);
        _validator = validator;
        return this;
    }
    
    public Variable Build()
    {
        return new Variable(_name , _description , _aliases , _value , _validator , _defaultValue);
    }
}