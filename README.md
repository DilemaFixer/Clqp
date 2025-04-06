# Clqp 🖥️

![build](https://img.shields.io/badge/build-passing-brightgreen)
![version](https://img.shields.io/badge/version-1.0.0-blue)
![license](https://img.shields.io/badge/license-MIT-green)
![language](https://img.shields.io/badge/language-C%23-blueviolet)

A command-line query processor library for building interactive command-line applications with routing, parameters validation, and variable management in C#.

## 📥 Installation

### Windows

```powershell
# Create a directory for the project
mkdir Clqp
cd Clqp

# Clone the repository
git clone https://github.com/DilemaFixer/Clqp.git .

```

### Unix-based systems (Linux, macOS)

```bash
# Create a directory for the project
mkdir Clqp
cd Clqp

# Clone the repository
git clone https://github.com/DilemaFixer/Clqp.git .

```

## 🚀 API and Usage Examples

### 🔄 Router

The Router is the core component that manages command routing and execution.

```csharp
public class Router
{
    public static GlobalVariable GlobalVariable;    // Global variable container accessible throughout the application
    private List<Command> _commands;                // List of registered commands
    private string _description;                    // Router description
    private string _version;                        // Router version
    private string _name;                           // Router name
    private string _contributor;                    // Router contributor
    private string _helloMessage;                   // Welcome message
    public string _commandNotFoundMessage;          // Message displayed when command is not found
}
```

**Methods:**

```csharp
// Creates a new RouterBuilder to configure a Router
public static RouterBuilder Builder()

// Adds a command to the router
public Router InsertCommand(Command command)

// Routes the inputs to the appropriate commands
public void Route(Input[] inputs)
```

**Usage Example:**

```csharp
// Create a router
Router router = Router
    .Builder()
    .Description("Command Line Query Processor")
    .Name("Clqp")
    .Version("1.0.0")
    .Contributor("Your Name")
    .HelloMessage("Welcome to Clqp!")
    .CommandNotFoundMessage("Command not found")
    .Build();

// Add commands
router.InsertCommand(someCommand);

// Route inputs
router.Route(inputs);
```

### 📋 Command

Commands represent the operations that can be invoked by users.

```csharp
public class Command
{
    public string Name { get; }                // Command name
    public string Description { get; }         // Command description
    public string[] Aliases { get; }           // Command aliases
    public bool RequiredInput { get; }         // Whether the command requires input
    public Arg Arg { get; }                    // Command arguments
    public List<Command> SubCommands { get; }  // Subcommands
    public object Object;                      // Object instance for method invocation
    public MethodInfo Method;                  // Method to invoke
}
```

**Methods:**

```csharp
// Creates a new CommandBuilder to configure a Command
public static CommandBuilder Builder(string name)

// Adds a subcommand to the command
public Command AddSubCommand(Command command)

// Executes the command with the given input
public void Execute(Input input)
```

**Usage Example:**

```csharp
// Create a command
Command command = Command
    .Builder("greet")
    .Description("Greets a user")
    .Aliases("g", "hello")
    .RequiredInput(true)
    .Arg(Arg
        .Builder()
        .AddParameter(Parameter
            .Builder("name")
            .Required(true)
            .Validator(s => !string.IsNullOrEmpty(s))
            .Build())
        .Build())
    .Build();

// Add a subcommand
command.AddSubCommand(anotherCommand);
```

### 🔍 Parameter

Parameters define the inputs that commands can accept.

```csharp
public class Parameter
{
    public string Name { get; }                // Parameter name
    public bool Required { get; }              // Whether the parameter is required
    public string DefaultValue { get; }        // Default value if parameter is not provided
    public Func<string, bool> Validator { get; } // Validation function
}
```

**Methods:**

```csharp
// Creates a new ParameterBuilder to configure a Parameter
public static ParameterBuilder Builder(string name)
```

**Usage Example:**

```csharp
// Create a parameter
Parameter parameter = Parameter
    .Builder("count")
    .Required(false)
    .DefaultValue("10")
    .Validator(s => int.TryParse(s, out _))
    .Build();
```

### 🛠️ Arg

Args are collections of parameters that commands can accept.

```csharp
public class Arg
{
    private List<Parameter> _parameters;    // List of parameters
}
```

**Methods:**

```csharp
// Creates a new ArgBuilder to configure an Arg
public static ArgBuilder Builder()

// Validates input parameters against defined parameters
public (string parameterName, string value)[] ValidateInputParameters((string parameterName, string value)[] parameters)
```

**Usage Example:**

```csharp
// Create an arg with multiple parameters
Arg arg = Arg
    .Builder()
    .AddParameter(Parameter.Builder("name").Required(true).Build())
    .AddParameter(Parameter.Builder("age").Required(false).DefaultValue("18").Build())
    .Build();
```

### 📊 Variable

Variables allow storing and retrieving values throughout the application.

```csharp
public class Variable
{
    public string Name { get; }                  // Variable name
    public string Description { get; }           // Variable description
    public string[] Aliases { get; }             // Variable aliases
    public string Value { get; set; }            // Variable value
    public string DefaultValue { get; }          // Default value
    public Func<string, bool> Validator { get; } // Validation function
}
```

**Methods:**

```csharp
// Creates a new VariableBuilder to configure a Variable
public static VariableBuilder Build(string name)
```

**Usage Example:**

```csharp
// Create a variable
Variable variable = Variable
    .Build("maxResults")
    .Description("Maximum number of results to display")
    .DefaultValue("20")
    .Validator(s => int.TryParse(s, out _))
    .Build();
```

### 🌐 GlobalVariable

GlobalVariable manages a collection of variables accessible throughout the application.

```csharp
public class GlobalVariable
{
    private List<Variable> _variables;    // List of variables
}
```

**Methods:**

```csharp
// Adds a variable to the global variable collection
public GlobalVariable Add(Variable variable)

// Adds multiple variables to the global variable collection
public GlobalVariable InsertRangeCommand(params Variable[] variables)

// Applies a cluster to work with the global variable
public GlobalVariable Work(ICluster<GlobalVariable> cluster)

// Sets a variable value
public void Set(string name, string value)

// Gets a variable value as a specific type
public T GetAs<T>(string name)
```

**Usage Example:**

```csharp
// Add a variable to the global variables
Router.GlobalVariable.Add(
    Variable.Build("theme")
        .Description("Application theme")
        .DefaultValue("dark")
        .Validator(s => s == "dark" || s == "light")
        .Build());

// Set a variable value
Router.GlobalVariable.Set("theme", "light");

// Get a variable value
string theme = Router.GlobalVariable.GetAs<string>("theme");
```

### 🔄 EndlessCycle

EndlessCycle provides an infinite loop to process user input.

```csharp
public class EndlessCycle : ICycle
{
    private Router _router;    // Router to route commands
    private IParser _parser;   // Parser to parse input
}
```

**Methods:**

```csharp
// Starts the endless cycle
public void Start()
```

**Usage Example:**

```csharp
// Create and start an endless cycle
EndlessCycle cycle = new EndlessCycle();
cycle.Start();
```

### 📝 Input

Input represents a parsed user input with route and parameters.

```csharp
public class Input
{
    public string[] Route { get; set; }                    // Command route (e.g., ["git", "commit"])
    public (string parameterName, string value)[] Parameters { get; set; }  // Parameter values
}
```

**Usage Example:**

```csharp
// Create an input
Input input = new Input
{
    Route = new[] { "user", "create" },
    Parameters = new[]
    {
        ("name", "John"),
        ("age", "25")
    }
};
```

## 📚 Dependencies

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
