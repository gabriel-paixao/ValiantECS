namespace ValiantECS
{
    public class EntityManager
    {
        private int _nextId = 1;

        public Entity CreateEntity()
        {
            return new Entity(_nextId++);
        }
    }
}
