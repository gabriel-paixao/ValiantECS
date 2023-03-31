using System.Collections.Generic;
using ValiantECS.Components;

namespace ValiantECS.Systems
{
    public class SystemManager
    {
        private List<ISystem> systems;

        public SystemManager()
        {
            systems = new List<ISystem>();
        }

        public void AddSystem(ISystem system)
        {
            systems.Add(system);
        }

        public void UpdateSystems(ComponentManager componentManager, float deltaTime)
        {
            foreach (var system in systems)
            {
                system.Update(componentManager, deltaTime);
            }
        }
    }
}
