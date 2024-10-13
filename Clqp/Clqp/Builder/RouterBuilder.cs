namespace Clqp.Builder;

public class RouterBuilder
{
    private string _description = "empty";
    private string _version = "1.0.0";
    private string _name = "Router";
    private string _contributor = "Clqp";
    private string _helloMessage = "Welcome to Clqp!";
    private string _commandNotFoundMessage = "Command not found";

    public RouterBuilder Description(string description)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(description);
        _description = description;
        return this;
    }

    public RouterBuilder Version(string version)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(version);
        _version = version;
        return this;
    }

    public RouterBuilder Name(string name)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name);
        _name = name;
        return this;
    }

    public RouterBuilder Contributor(string contributor)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(contributor);
        _contributor = contributor;
        return this;
    }

    public RouterBuilder HelloMessage(string helloMessage)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(helloMessage);
        _helloMessage = helloMessage;
        return this;
    }
    
    public RouterBuilder CommandNotFoundMessage(string commandNotFoundMessage)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(commandNotFoundMessage);
        _commandNotFoundMessage = commandNotFoundMessage;
        return this;
    }

    public Router Build()
    {
        return new Router(_description , _version , _name , _contributor , _helloMessage , _commandNotFoundMessage);
    }
}