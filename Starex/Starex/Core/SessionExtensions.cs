using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Starex.Core
{
    public static class SessionExtensions
    {
        public static void SetSession<T>(this ISession session,string key,T entity)
        {
            session.SetString(key, JsonSerializer.Serialize(entity));
        }
        public static T GetSession<T>( this ISession session, string key)
        {
          var result=   session.GetString(key);
           return JsonSerializer.Deserialize<T>(result);
        }
    }
}
