
namespace _146.LRUCache;

public class LRUCache
{
    private readonly Dictionary<int, int> _cache;
    private List<int> _keys;
    private readonly int _capacity;
    private int _size = 0;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _keys = new List<int>();
        _cache = new Dictionary<int, int>();
    }

    public int Get(int key)
    {
        if (!_keys.Contains(key)) return -1;

        _keys.Add(key);
        _keys.Remove(key);
        return _cache[key];
    }

    public void Put(int key, int value)
    {
        if (_keys.Contains(key))
        {
            _cache[key] = value;
            _keys.Remove(key);
        }
        else if (_size < _capacity)
        {
            _size++;
            _cache.Add(key, value);
        }
        else
        {
            _cache.Remove(_keys.First());
            _keys.RemoveAt(0);
            _cache.Add(key, value);
        }
        _keys.Add(key);
    }
}