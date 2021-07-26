using System;
using System.Collections.Generic;

namespace ClientBase.Infrastructure
{
    public static class GlobalConfiguration
    {
        public static IList<Type> EntitiesTypes { get; set; } = new List<Type>();
    }
}
