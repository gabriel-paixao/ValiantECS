using System.Collections.Generic;
using System;
using System.Linq;

namespace ValiantECS
{
    public class ComponentManager
    {
        private readonly Dictionary<Type, Dictionary<int, object>> _componentStore;

        public ComponentManager()
        {
            _componentStore = new Dictionary<Type, Dictionary<int, object>>();
        }

        public void AddComponent<T>(Entity entity, T component)
        {
            var type = typeof(T);

            if (!_componentStore.ContainsKey(type))
            {
                _componentStore[type] = new Dictionary<int, object>();
            }

            _componentStore[type][entity.Id] = component;
        }

        public T GetComponent<T>(Entity entity)
        {
            var type = typeof(T);

            if (_componentStore.TryGetValue(type, out var components))
            {
                if (components.TryGetValue(entity.Id, out var component))
                {
                    return (T)component;
                }
            }

            return default(T);
        }

        public IEnumerable<Entity> GetEntitiesWithComponents<T>() where T : struct
        {
            var type = typeof(T);

            if (_componentStore.TryGetValue(type, out var components))
            {
                return components.Keys.Select(id => new Entity(id));
            }

            return Enumerable.Empty<Entity>();
        }

        public bool HasComponent<T>(Entity entity)
        {
            var type = typeof(T);

            if (_componentStore.TryGetValue(type, out var components))
            {
                return components.ContainsKey(entity.Id);
            }

            return false;
        }
    }
}
