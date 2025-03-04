public class DynamicArray
{
    private Contact[] _array;
    private int _size;
    private int _capacity;

    public DynamicArray(int capacity = 10)
    {
        _capacity = capacity;
        _array = new Contact[_capacity];
        _size = 0;
    }

    public void Add(Contact contact)
    {
        if (_size == _capacity)
        {
            Resize();
        }
        _array[_size] = contact;
        _size++;
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < _size)
        {
            for (int i = index; i < _size - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _size--;
        }
    }

    public Contact Get(int index)
    {
        if (index >= 0 && index < _size)
        {
            return _array[index];
        }
        return null;
    }

    public void Set(int index, Contact contact)
    {
        if (index >= 0 && index < _size)
        {
            _array[index] = contact;  
        }
    }

    public int Size() => _size;

    private void Resize()
    {
        _capacity *= 2;
        Contact[] newArray = new Contact[_capacity];
        for (int i = 0; i < _size; i++)
        {
            newArray[i] = _array[i];
        }
        _array = newArray;
    }
}
