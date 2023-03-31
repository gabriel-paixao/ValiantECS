using System.Collections.Generic;

namespace ValiantECS
{
    public class World
    {
        private readonly EntityManager _entityManager;
        private readonly ComponentManager _componentManager;
        private readonly List<System> _systems;

        public EntityManager EntityManager => _entityManager;
        public ComponentManager ComponentManager => _componentManager;

        public World()
        {
            _entityManager = new EntityManager();
            _componentManager = new ComponentManager();
            _systems = new List<System>();
        }

        public Entity CreateEntity()
        {
            return _entityManager.CreateEntity();
        }

        public void AddComponent<T>(Entity entity, T component)
        {
            _componentManager.AddComponent(entity, component);
        }

        public T GetComponent<T>(Entity entity)
        {
            return _componentManager.GetComponent<T>(entity);
        }

        public void AddSystem(System system)
        {
            _systems.Add(system);
        }

        public void Update()
        {
            foreach (var system in _systems)
            {
                system.Update();
            }
        }
    }
}
