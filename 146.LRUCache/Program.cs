
using _146.LRUCache;

var cache = new LRUCache(2);
cache.Put(1,1);
cache.Put(2,2);
cache.Get(1);
cache.Put(3,3);
cache.Get(2);
cache.Put(4,4);
cache.Get(1);
cache.Get(3);
cache.Get(4);