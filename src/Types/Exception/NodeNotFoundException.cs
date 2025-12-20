using System.Buffers.Text;

namespace SteelTowers.Types.Exception;

public class NodeNotFoundException: System.Exception
{
    public NodeNotFoundException(): base()
    {
        
    }

    public NodeNotFoundException(string message): base(message)
    {
        
    }

    public NodeNotFoundException(string message, System.Exception inner): base(message, inner)
    {
        
    }
}