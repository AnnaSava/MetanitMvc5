using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace MetanitMvc5.Db
{
    public class AppCache
    {
        public Phone GetValue(int id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(id.ToString()) as Phone;
        }

        public bool Add(Phone value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

        public void Update(Phone value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

        public void Delete(int id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(id.ToString()))
            {
                memoryCache.Remove(id.ToString());
            }
        }
    }
}