using System.Reflection;
using Clqp.Builder;

namespace Clqp;

public class Command
{
    public Command(string name, string description, string[] aliases, bool requiredInput, Arg arg)
    {
        Name = name;
        Description = description;
        Aliases = aliases;
        RequiredInput = requiredInput;
        Arg = arg;
    }

    public static CommandBuilder Builder(string name) => new(name);

    public string Name { get; }
    public string Description { get; }
    public string[] Aliases { get; }
    public bool RequiredInput { get; }
    public Arg Arg { get; }
    public List<Command> SubCommands { get; } = new();

    public object Object;
    public MethodInfo Method;
    
    public Command AddSubCommand(Command command)
    {
        ArgumentNullException.ThrowIfNull(command);
        SubCommands.Add(command);
        return this;
    }
    
    public void Execute(Input input)
    {
        if (Object == null || Method == null)
        {
            throw new System.Exception("Object or Method is null");
        }

        object[] inputParameters = null;
        
        if (RequiredInput)
        {
            input.Parameters = Arg.ValidateInputParameters(input.Parameters);
            inputParameters = input.Parameters.Select(p => p.value).ToArray();
        }

        Method.Invoke(Object , inputParameters);
    }
    
}