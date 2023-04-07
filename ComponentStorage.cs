using System.Collections.Generic;

namespace ValiantECS
{
    public class ComponentStorage<T> : IComponentStorage where T : new()
    {
        private Dictionary<Entity, T> _storage;
        private World _world;

        public ComponentStorage(World world)
        {
            _storage = new Dictionary<Entity, T>();
            _world = world;
        }

        public void Add(Entity entity, T component)
        {
            _storage[entity] = component;
            _world.InvalidateJoinCache();
        }

        public T Get(Entity entity)
        {
            return _storage[entity];
        }

        public void Remove(Entity entity)
        {
            _storage.Remove(entity);
            _world.InvalidateJoinCache();
        }

        public List<Entity> GetEntities()
        {
            return new List<Entity>(_storage.Keys);
        }        
    }
}
