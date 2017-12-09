using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetanitMvc5.Annotations
{
    public class CacheAttribute : ActionFilterAttribute
    {
        // Время кэширования, по умолчанию - 3600 секунд
        public int Duration { get; set; }

        public CacheAttribute()
        {
            Duration = 3600;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // если установили длительность в 0, то кэширование не применяется
            if (Duration <= 0) return;

            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            TimeSpan cacheDuration = TimeSpan.FromSeconds(Duration);
            // задаем публичный кэш
            cache.SetCacheability(HttpCacheability.Public);
            // установка продолжительности кэширования
            cache.SetExpires(DateTime.Now.Add(cacheDuration));
            // установка параметра max-age
            cache.SetMaxAge(cacheDuration);
            // добавляем дополнительные параметры для кэширования
            cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
        }
    }
}