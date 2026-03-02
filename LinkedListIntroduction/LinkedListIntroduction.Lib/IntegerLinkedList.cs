namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode _head;
   
    public IntegerLinkedList()
    {
        _head = null;
    }

    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }

    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;

    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);
    }

    public void Prepend(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Prepend(v);
    }

    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}

public class IntegerNode
{
    int _value;
    IntegerNode _next;

     internal int Count => _next == null ? 1 : 1 + _next.Count;
            
    internal int Sum => _next == null ? _value : _value + _next.Sum;


    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }

    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    internal void Prepend(int v)
    {
        var newNode = new IntegerNode(v);
        newNode._next = this;
        _value = newNode._value;
        _next = newNode._next;
    }

    internal void deletevalue(int v)
    {
        
    }
    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }

}
