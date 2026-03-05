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
    
    public bool DeleteValue(int v)
    {
        if (_head == null)
            return false;
        if (_head.deletevalue(v, null))
        {
            if (_head._value == v)
                _head = _head._next;
            return true;
        }
        return false;
    }

    public void insertValue(int v, int position)
    {
        if (position < 0)
            throw new ArgumentOutOfRangeException(nameof(position), "Position must be non-negative.");
        
        if (position == 0)
        {
            Prepend(v);
            return;
        }

        IntegerNode current = _head;
        for (int i = 1; i < position; i++)
        {
            if (current == null)
                throw new ArgumentOutOfRangeException(nameof(position), "Position exceeds the length of the list.");
            current = current._next;
        }
        if (current == null)
            throw new ArgumentOutOfRangeException(nameof(position), "Position exceeds the length of the list.");

        var newNode = new IntegerNode(v);
        newNode._next = current._next;
        current._next = newNode;
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
        var newNode = new IntegerNode(v);
        newNode._next = _head;
        _head = newNode;
    }

    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}

public class IntegerNode
{
    public int _value;
    public IntegerNode _next;

     internal int Count => _next == null ? 1 : 1 + _next.Count;
            
    internal int Sum => _next == null ? _value : _value + _next.Sum;


    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }
    
    internal bool deletevalue(int v, IntegerNode previous)
    {
        if (_value == v)
        {
            if (previous != null)
                previous._next = _next;
            return true;
        }
        else
        {
            if (_next == null)
                return false;
            else
                return _next.deletevalue(v, this);
        }
    }

    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }

}
