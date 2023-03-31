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

        public virtual void RemoveComponent(int entityId)
        {
            // This method should be implemented in the derived class
            throw new NotImplementedException();
        }

        public void RemoveComponent<T>(int entityId) where T : struct, IComponent
        {
            var storage = GetStorage<T>();

            if (storage.Remove(entityId))
            {
                int denseIndex = storage.EntitySet.GetDenseIndex(entityId);
                int lastIndex = storage.EntitySet.Count - 1;

                if (denseIndex != lastIndex)
                {
                    int lastEntityId = storage.EntitySet.GetDenseIndex(lastIndex);
                    T lastComponent = storage.Components[lastIndex];

                    storage.Components[denseIndex] = lastComponent;
                    storage.EntitySet.Move(lastEntityId, denseIndex);
                }

                storage.Components.RemoveAt(lastIndex);
            }
        }
    }

    public class ComponentManager<T> : ComponentManager where T : struct, IComponent
    {
        public override void RemoveComponent(int entityId)
        {
            // Call the generic RemoveComponent method with the proper type argument
            RemoveComponent<T>(entityId);
        }
    }
}
