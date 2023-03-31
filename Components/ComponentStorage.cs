using System.Collections.Generic;
using ValiantECS.Utils;

namespace ValiantECS.Components
{
    public class ComponentStorage<T> where T : struct, IComponent
    {
        private SparseSet _entitySet;
        private List<T> _components;

        public SparseSet EntitySet => _entitySet;
        public List<T> Components => _components;

        public ComponentStorage()
        {
            _entitySet = new SparseSet();
            _components = new List<T>();
        }

        public void Add(int entityId, T component)
        {
            _entitySet.Add(entityId);
            _components.Add(component);
        }

        public bool Remove(int entityId)
        {
            if (_entitySet.Contains(entityId))
            {
                _entitySet.Remove(entityId);
                return true;
            }
            return false;
        }

        public bool TryGetComponent(int entityId, out T component)
        {
            if (_entitySet.Contains(entityId))
            {
                component = _components[_entitySet.GetDenseIndex(entityId)];
                return true;
            }
            component = default(T);
            return false;
        }
    }
}
