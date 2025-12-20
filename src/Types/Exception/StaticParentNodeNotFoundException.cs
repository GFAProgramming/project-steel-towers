namespace SteelTowers.Types.Exception;

public class StaticParentNodeNotFoundException: NodeNotFoundException
{
    public StaticParentNodeNotFoundException(): base()
    {
        
    }
    
    public StaticParentNodeNotFoundException(string message): base(message)
    {
        
    }

    public StaticParentNodeNotFoundException(string message, System.Exception inner): base(message, inner)
    {
        
    }
}