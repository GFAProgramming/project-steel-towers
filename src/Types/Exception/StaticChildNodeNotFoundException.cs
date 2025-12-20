namespace SteelTowers.Types.Exception;

public class StaticChildNodeNotFoundException: NodeNotFoundException
{
    public StaticChildNodeNotFoundException(): base()
    {
        
    }
    
    public StaticChildNodeNotFoundException(string message): base(message)
    {
        
    }

    public StaticChildNodeNotFoundException(string message, System.Exception inner): base(message, inner)
    {
        
    }
}