using System.Collections.Generic;
using ValiantECS.Utils;

namespace ValiantECS.Components
{
    public class ComponentStorage<T> where T : struct, IComponent
    {
        private SparseSet entitySet;
        private List<T> components;

        public ComponentStorage()
        {
            entitySet = new SparseSet();
            components = new List<T>();
        }

        public void Add(int entityId, T component)
        {
            entitySet.Add(entityId);
            components.Add(component);
        }

        public bool Remove(int entityId)
        {
            if (entitySet.Contains(entityId))
            {
                entitySet.Remove(entityId);
                return true;
            }
            return false;
        }

        public bool TryGetComponent(int entityId, out T component)
        {
            if (entitySet.Contains(entityId))
            {
                component = components[entitySet.GetDenseIndex(entityId)];
                return true;
            }
            component = default(T);
            return false;
        }
    }
}
