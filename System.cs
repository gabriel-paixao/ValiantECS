namespace ValiantECS
{
    public abstract class System
    {
        protected readonly EntityManager EntityManager;
        protected readonly ComponentManager ComponentManager;

        protected System(EntityManager entityManager, ComponentManager componentManager)
        {
            EntityManager = entityManager;
            ComponentManager = componentManager;
        }

        public abstract void Update();
    }
}
