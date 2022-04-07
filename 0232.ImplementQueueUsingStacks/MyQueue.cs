namespace _0232.ImplementQueueUsingStacks;

public class MyQueue
{
    private Stack<int> _s = new();

    public void Push(int x)
    {
        _s.Push(x);
    }

    public int Pop()
    {
        _s = new Stack<int>(_s);
        var ret = _s.Pop();
        _s = new Stack<int>(_s);
        return ret;
    }

    public int Peek()
    {
        _s = new Stack<int>(_s);
        var ret = _s.Peek();
        _s = new Stack<int>(_s);
        return ret;
    }

    public bool Empty()
    {
        return !_s.Any();
    }
}