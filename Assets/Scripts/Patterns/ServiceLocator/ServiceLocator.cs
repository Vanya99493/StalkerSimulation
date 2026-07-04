using System;
using System.Collections.Generic;
using UnityEngine;

namespace StalkerSimulation
{
	public class ServiceLocator
	{
		public static ServiceLocator Instance { get; } = new ServiceLocator();
		
		private readonly Dictionary<Type, IService> _services = new();

		public T Get<T>() where T : IService
		{
			Type type = typeof(T);
			if (!_services.ContainsKey(type))
			{
				Debug.LogError($"{type} is unregistered!");
				throw new InvalidOperationException();
			}

			return (T)_services[type];
		}
		
		public void Register<T>(T service) where T : IService
		{
			Type type = typeof(T);
			if (_services.ContainsKey(type))
			{
				Debug.LogError($"Cannot register already registered service with type: {type}");
				return;
			}
			
			_services.Add(type, service);
		}

		public void Unregister<T>() where T : IService
		{
			Type type = typeof(T);
			if (!_services.ContainsKey(type))
			{
				Debug.Log($"Cannot unregister nonexistent service with type: {type}");
				return;
			}

			_services.Remove(type);
		}
	}
}