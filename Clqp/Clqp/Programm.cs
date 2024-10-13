namespace Clqp;

public class Programm
{
    public void Main()
    {
        Router router = Router
            .Builder()
            .Description("A simple router")
            .Name("SimpleRouter")
            .Version("1.0.0")
            .Contributor("Clqp")
            .HelloMessage("Hello, World!")
            .Build();
        
        router.InsertCommand(Command
                .Builder("test")
                .Aliases("t")
                .Description("description")
                .RequiredInput(true)
                .Arg(Arg
                    .Builder()
                    .AddParameter(Parameter
                        .Builder("name")
                        .DefaultValue("default")
                        .Build())
                    .Build())
                .Build());
        
        Router.GlobalVariable.Add(
            Variable.Build("dfd")
                .Description("description")
                .DefaultValue("default")
                .Validator(s => s.Length > 0)
                .Build());
    }
}