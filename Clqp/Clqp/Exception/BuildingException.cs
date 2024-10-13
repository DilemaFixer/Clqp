namespace Clqp.Exception;

public class BuildingException : System.Exception
{
    public string Builder { get; }
    public string Message { get; }
    
    public BuildingException(string builder, string message) : base($"Error in builder {builder}: {message}")
    {
        Builder = builder;
        Message = message;
    }
}