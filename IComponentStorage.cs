using System.Collections.Generic;

namespace ValiantECS
{
    public interface IComponentStorage
    {
        List<Entity> GetEntities();
        void Remove(Entity entity);
    }
}
