using Clqp.Builder;

namespace Clqp;

public class Router
{
    public static GlobalVariable GlobalVariable = new();

    private List<Command> _commands = new();
    private string _description;
    private string _version;
    private string _name;
    private string _contributor;
    private string _helloMessage;
    public string _commandNotFoundMessage;

    public Router(string description, string version, string name, string contributor, string helloMessage, string commandNotFoundMessage)
    {
        _description = description;
        _version = version;
        _name = name;
        _contributor = contributor;
        _helloMessage = helloMessage;
        _commandNotFoundMessage = commandNotFoundMessage;
    }

    public static RouterBuilder Builder()
    {
        return new RouterBuilder();
    }

    public Router InsertCommand(Command command)
    {
        _commands.Add(command);
        return this;
    }

    public void Route(Input[] inputs)
    {
        foreach (Input input in inputs)
        {
            var command = FindCommand(input.Route);
            command?.Execute(input);
        }
    }

    private Command FindCommand(string[] route)
    {
        List<Command> commands = _commands;

        for (int i = 0; i < route.Length; i++)
        {
            for (int j = 0; j < commands.Count; j++)
            {
                if (commands[j].Name == route[i] || commands[j].Aliases.Contains(route[i]))
                {
                    if(IsLast(i , route))
                    {
                        return commands[j];
                    }
                    
                    commands = commands[j].SubCommands;
                }
            }
        }
        
        Console.WriteLine(_commandNotFoundMessage);
        return null;
    }
    
    private bool IsLast<T>(int index , IEnumerable<T> list)
    {
        return index == list.Count() - 1;
    }
}