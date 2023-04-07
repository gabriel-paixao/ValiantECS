using System.Collections.Generic;

namespace ValiantECS
{
    public class ComponentStorage<T> : IComponentStorage where T : new()
    {
        private Dictionary<Entity, T> _storage;

        public ComponentStorage()
        {
            _storage = new Dictionary<Entity, T>();
        }

        public void Add(Entity entity, T component)
        {
            _storage[entity] = component;
        }

        public T Get(Entity entity)
        {
            return _storage[entity];
        }

        public void Remove(Entity entity)
        {
            _storage.Remove(entity);
        }

        public List<Entity> GetEntities()
        {
            return new List<Entity>(_storage.Keys);
        }        
    }
}
