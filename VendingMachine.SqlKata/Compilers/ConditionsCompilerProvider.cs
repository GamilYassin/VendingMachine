using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VendingMachine.QueryBuilder
{
    internal class ConditionsCompilerProvider
    {
        #region Fields

        private readonly Type compilerType;
        private readonly Dictionary<string, MethodInfo> methodsCache = new Dictionary<string, MethodInfo>();
        private readonly object syncRoot = new object();

        #endregion Fields

        #region Constructors

        public ConditionsCompilerProvider(Compiler compiler)
        {
            this.compilerType = compiler.GetType();
        }

        #endregion Constructors

        #region Methods

        private MethodInfo FindMethodInfo(Type clauseType, string methodName)
        {
            MethodInfo methodInfo = compilerType
                .GetRuntimeMethods()
                .FirstOrDefault(x => x.Name == methodName);

            if (methodInfo == null)
            {
                throw new Exception($"Failed to locate a compiler for '{methodName}'.");
            }

            if (clauseType.IsConstructedGenericType && methodInfo.GetGenericArguments().Any())
            {
                methodInfo = methodInfo.MakeGenericMethod(clauseType.GenericTypeArguments);
            }

            return methodInfo;
        }

        public MethodInfo GetMethodInfo(Type clauseType, string methodName)
        {
            // The cache key should take the type and the method name into consideration
            var cacheKey = methodName + "::" + clauseType.FullName;

            lock (syncRoot)
            {
                if (methodsCache.ContainsKey(cacheKey))
                {
                    return methodsCache[cacheKey];
                }

                return methodsCache[cacheKey] = FindMethodInfo(clauseType, methodName);
            }
        }

        #endregion Methods
    }
}