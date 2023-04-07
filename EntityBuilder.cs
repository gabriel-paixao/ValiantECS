namespace ValiantECS
{
    public class EntityBuilder
    {
        private World _world;
        private Entity _entity;

        public EntityBuilder(World world, Entity entity)
        {
            _world = world;
            _entity = entity;
        }

        public EntityBuilder With<T>(T component) where T : new()
        {
            var storage = _world.GetComponentStorage<T>();
            storage.Add(_entity, component);
            return this;
        }

        public Entity Build()
        {
            return _entity;
        }
    }
}
