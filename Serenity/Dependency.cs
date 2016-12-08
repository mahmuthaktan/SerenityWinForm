
using Serenity;
using Serenity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity.Abstractions
{
    public static class Dependency
    {
        public static TType Resolve<TType>() where TType : class;
        public static TType Resolve<TType>(string name) where TType : class;
        public static TType TryResolve<TType>() where TType : class;
        public static TType TryResolve<TType>(string name) where TType : class;

        public static IDependencyResolver SetResolver(IDependencyResolver value);
        public static IDependencyResolver Resolver { get; }
        public static bool HasResolver { get; }
    }
}
