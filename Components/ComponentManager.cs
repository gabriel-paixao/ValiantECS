using System;
using System.Collections.Generic;

namespace ValiantECS.Components
{
    public class ComponentManager
    {
        private Dictionary<Type, object> storages;

        public ComponentManager()
        {
            storages = new Dictionary<Type, object>();
        }

        public ComponentStorage<T> GetStorage<T>() where T : struct, IComponent
        {
            Type type = typeof(T);
            if (!storages.TryGetValue(type, out object storage))
            {
                storage = new ComponentStorage<T>();
                storages[type] = storage;
            }

            return (ComponentStorage<T>)storage;
        }
    }
}
