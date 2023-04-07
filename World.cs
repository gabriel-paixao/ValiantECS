using System;
using System.Collections.Generic;

namespace ValiantECS
{
    public class World
    {
        private int _ids = 0;
        private List<Entity> _entities;
        private Dictionary<Type, IComponentStorage> _componentStorages;

        public World()
        {
            _entities = new List<Entity>();
            _componentStorages = new Dictionary<Type, IComponentStorage>();
        }

        public void RegisterComponent<T>() where T : new()
        {
            var componentType = typeof(T);
            _componentStorages[componentType] = new ComponentStorage<T>();
        }

        public EntityBuilder CreateEntity()
        {
            var entity = new Entity() { Id = _ids++ };
            _entities.Add(entity);
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
        }

        public List<Entity> GetEntities()
        {
            return new List<Entity>(_entities);
        }
    }

}
