using System;
using System.Collections.Generic;
using UnityEngine;

namespace SDB.Core
{
    /// <summary>Registo simples de serviços (composition root fica em SDB.Services).</summary>
    public static class ServiceLocator
    {
        static readonly Dictionary<Type, object> Services = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Reset() => Services.Clear();

        public static void Register<T>(T service) where T : class => Services[typeof(T)] = service;

        public static T Get<T>() where T : class
        {
            if (Services.TryGetValue(typeof(T), out var o)) return (T)o;
            throw new InvalidOperationException($"Serviço não registado: {typeof(T).Name}");
        }

        public static bool TryGet<T>(out T service) where T : class
        {
            if (Services.TryGetValue(typeof(T), out var o)) { service = (T)o; return true; }
            service = null;
            return false;
        }

        public static void Clear() => Services.Clear();
    }
}
