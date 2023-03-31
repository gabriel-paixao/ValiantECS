namespace ValiantECS.Example
{
    public class HealthSystem : System
    {
        public HealthSystem(EntityManager entityManager, ComponentManager componentManager)
            : base(entityManager, componentManager) { }

        public override void Update()
        {
            var entitiesWithHealth = ComponentManager.GetEntitiesWithComponents<HealthComponent>();

            foreach (var entity in entitiesWithHealth)
            {
                var health = ComponentManager.GetComponent<HealthComponent>(entity);

                if (health.Current > health.Max)
                {
                    health.Current = health.Max;
                    ComponentManager.AddComponent(entity, health);
                }
            }
        }
    }
}
