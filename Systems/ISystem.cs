using ValiantECS.Components;

namespace ValiantECS.Systems
{
    public interface ISystem
    {
        void Update(ComponentManager componentManager, float deltaTime);
    }
}
