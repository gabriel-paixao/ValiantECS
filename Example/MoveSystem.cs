namespace ValiantECS.Example
{
    public class MoveSystem : System
    {
        public MoveSystem(EntityManager entityManager, ComponentManager componentManager)
            : base(entityManager, componentManager) { }

        public void MoveEntity(Entity entity, int deltaX, int deltaY)
        {
            if (!ComponentManager.HasComponent<MoveComponent>(entity))
            {
                return;
            }

            var position = ComponentManager.GetComponent<PositionComponent>(entity);
            position.X += deltaX;
            position.Y += deltaY;
            ComponentManager.AddComponent(entity, position);
        }

        public override void Update()
        {
            //Update
        }
    }
}
