namespace Clqp;

public class EndlessCycle : ICycle
{
    private Router _router;
    private IParser _parser;
    
    public void Start()
    {
        while (true)
        {
            Console.Write(">> ");
            string input = Console.ReadLine();
            
            var inputs =_parser.Parse(input);
            _router.Route(inputs);
        }
    }
}