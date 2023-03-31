using System;
using System.Collections.Generic;
using ValiantECS.Components;
using ValiantECS.Systems;

namespace ValiantECS
{
    public class World
    {
        private readonly Dictionary<Type, ComponentManager> _componentManagers;
        private readonly List<ISystem> _systems;

        private int _nextEntityId = 0;

        public World()
        {
            _componentManagers = new Dictionary<Type, ComponentManager>();
            _systems = new List<ISystem>();
        }

        public int CreateEntity()
        {
            int entityId = _nextEntityId;
            _nextEntityId++;
            return entityId;
        }

        public void DestroyEntity(int entityId)
        {
            foreach (var componentManager in _componentManagers.Values)
            {
                componentManager.RemoveComponent(entityId);
            }
        }
    }
}
