using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TodoListProject.Extensions
{
    public static class SessionExtensionMethod
    {
        public static void SetObject( this ISession session, string key, Object value)
        {
            var stringObject = JsonConvert.SerializeObject(value);
            session.SetString(key, stringObject);
        }

        public static T GetObject<T>(this  ISession session, string key) where T : class
        {
            var stringObject = session.GetString(key);
            if (stringObject==null)
            {
                return null;
            }
            var value = JsonConvert.DeserializeObject<T>(stringObject);
            return value;
        }
    }
}
