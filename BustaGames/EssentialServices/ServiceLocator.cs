using System;
using System.Collections.Generic;
using UnityEngine;

namespace BustaGames.EssentialServices {
    public static class ServiceLocator{
        private static readonly Dictionary<Type, IService> serviceMap = new Dictionary<Type, IService>();

        public static void AddService<T>(T service) where T: IService
        {
            var key = typeof(T);
            if (serviceMap.ContainsKey(key)) {
                return;
            }

            serviceMap.Add(key, service);
        }

        public static T GetService<T>() where T : IService
        {
            var key = typeof(T);
            if (!serviceMap.TryGetValue(key, out var serviceObject)) {
                Debug.LogError("Service not found.");
                return default;
            }

            if (!(serviceObject is T service)) {
                Debug.LogError("Service not of specified type.");
                return default;
            }

            return service;
        }

        public static bool TryGetService<T>(out T service)
        {
            var key = typeof(T);
            var result = serviceMap.TryGetValue(key, out var s);
            service = (T) s;
            return result;
        }
    }
}