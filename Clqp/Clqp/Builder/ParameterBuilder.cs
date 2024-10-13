namespace Clqp.Builder;

public class ParameterBuilder
{
    private string _name;
    private bool _required;
    private string _defaultValue;
    private Func<string, bool> _validator;

    public ParameterBuilder(string name)
    {
        _name = name;
    }
    
    public ParameterBuilder Required(bool required)
    {
        _required = required;
        return this;
    }
    
    public ParameterBuilder DefaultValue(string defaultValue)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(defaultValue);
        _defaultValue = defaultValue;
        return this;
    }
    
    public ParameterBuilder Validator(Func<string, bool> validator)
    {
        ArgumentNullException.ThrowIfNull(validator);
        _validator = validator;
        return this;
    }
    
    public Parameter Build()
    {
        return new Parameter(_name , _required , _defaultValue , _validator);
    }
}