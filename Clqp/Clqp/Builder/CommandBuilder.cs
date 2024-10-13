using Clqp.Exception;

namespace Clqp.Builder;

public class CommandBuilder
{
    private string _name;
    private string _description = "empty description";
    private bool _requiredInput;
    private string[] _aliases = {};
    private Arg _arg;

    public CommandBuilder(string name)
    {
        _name = name;
    }
    
    public CommandBuilder Description(string description)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(description);
        _description = description;
        return this;
    }
    
    public CommandBuilder Name(string name)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name);
        _name = name;
        return this;
    }
    
    public CommandBuilder Aliases(params string[] aliases)
    {
        ArgumentNullException.ThrowIfNull(aliases);
        _aliases = aliases;
        return this;
    }
    
    public CommandBuilder RequiredInput(bool requiredInput)
    {
        _requiredInput = requiredInput;
        return this;
    }
    
    public CommandBuilder Arg(Arg arg)
    {
        ArgumentNullException.ThrowIfNull(arg);
        _arg = arg;
        return this;
    }
    
    public Command Build()
    {
        if (_requiredInput && _arg == null)
            throw new BuildingException("CommandBuilder", "RequiredInput is true but Arg is null");
        
        return new Command(_name , _description , _aliases , _requiredInput , _arg);
    }
}