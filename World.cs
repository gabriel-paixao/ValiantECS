using System;
using System.Collections.Generic;
using System.Linq;

namespace ValiantECS
{
    public class World
    {
        private int _ids = 0;
        private List<Entity> _entities;
        private Dictionary<Type, object> _resources;
        private Dictionary<Type, IComponentStorage> _componentStorages;
        public Dictionary<string, object> JoinCache { get; set; }

        public World()
        {
            _entities = new List<Entity>();
            _componentStorages = new Dictionary<Type, IComponentStorage>();
            _resources = new Dictionary<Type, object>();
            JoinCache = new Dictionary<string, object>();
        }

        public void RegisterComponent<T>() where T : new()
        {
            var componentType = typeof(T);
            _componentStorages[componentType] = new ComponentStorage<T>(this);
        }

        public EntityBuilder CreateEntity()
        {
            var entity = new Entity() { Id = _ids++ };
            _entities.Add(entity);
            InvalidateJoinCache();
            return new EntityBuilder(this, entity);
        }

        public ComponentStorage<T> GetComponentStorage<T>() where T : new()
        {
            var componentType = typeof(T);
            return (ComponentStorage<T>)_componentStorages[componentType];
        }

        public void DeleteEntity(Entity entity)
        {
            _entities.Remove(entity);

            foreach (var componentStorage in _componentStorages.Values)
            {
                componentStorage.Remove(entity);
            }
            InvalidateJoinCache();
        }

        public List<Entity> GetEntities()
        {
            return new List<Entity>(_entities);
        }

        public void WriteResource<T>(T resource)
        {
            var resourceType = typeof(T);
            _resources[resourceType] = resource;
        }

        public T ReadResource<T>()
        {
            var resourceType = typeof(T);
            return (T)_resources[resourceType];
        }

        public T ReadResource<T>(out bool found)
        {
            var resourceType = typeof(T);
            if (_resources.TryGetValue(resourceType, out object resource))
            {
                found = true;
                return (T)resource;
            }
            else
            {
                found = false;
                return default(T);
            }
        }

        public string GenerateJoinCacheKey(params Type[] componentTypes)
        {
            return string.Join("|", componentTypes.Select(t => t.FullName));
        }

        public void InvalidateJoinCache()
        {
            JoinCache.Clear();
        }
    }
}
