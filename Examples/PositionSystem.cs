using ValiantECS.Components;
using ValiantECS.Systems;

namespace ValiantECS.Examples
{
    public class PositionSystem : ISystem
    {
        public void Update(ComponentManager componentManager, float deltaTime)
        {
            var positionStorage = componentManager.GetStorage<PositionComponent>();

            // Process entities with PositionComponent here
        }
    }
}
