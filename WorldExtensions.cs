using System.Collections.Generic;
using System.Linq;

namespace ValiantECS
{
    public static class WorldExtensions
    {
        public static IEnumerable<(T1, Entity)> Join<T1>(this World world)
           where T1 : new()           
        {
            var storage1 = world.GetComponentStorage<T1>();

            var entities1 = storage1.GetEntities();

            return entities1.Select(entity => (storage1.Get(entity), entity));
        }

        public static IEnumerable<(T1, T2, Entity)> Join<T1, T2>(this World world)
            where T1 : new()
            where T2 : new()
        {
            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();

            var joinedEntities = entities1.Intersect(entities2);

            return joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), entity));
        }

        public static IEnumerable<(T1, T2, T3, Entity)> Join<T1, T2, T3>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
        {
            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();

            var joinedEntities = entities1.Intersect(entities2);
            joinedEntities = joinedEntities.Intersect(entities3);

            return joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), entity));
        }

        public static IEnumerable<(T1, T2, T3, T4, Entity)> Join<T1, T2, T3, T4>(this World world)
           where T1 : new()
           where T2 : new()
           where T3 : new()
           where T4 : new()
        {
            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();

            var joinedEntities = entities1.Intersect(entities2);
            joinedEntities = joinedEntities.Intersect(entities3);
            joinedEntities = joinedEntities.Intersect(entities4);

            return joinedEntities.Select(entity => (storage1.Get(entity),
                                                    storage2.Get(entity),
                                                    storage3.Get(entity),
                                                    storage4.Get(entity),
                                                    entity));
        }

        public static IEnumerable<(T1, T2, T3, T4, T5, Entity)> Join<T1, T2, T3, T4, T5>(this World world)
           where T1 : new()
           where T2 : new()
           where T3 : new()
           where T4 : new()
           where T5 : new()
        {
            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();
            var storage5 = world.GetComponentStorage<T5>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();
            var entities5 = storage5.GetEntities();

            var joinedEntities = entities1.Intersect(entities2);
            joinedEntities = joinedEntities.Intersect(entities3);
            joinedEntities = joinedEntities.Intersect(entities4);
            joinedEntities = joinedEntities.Intersect(entities5);

            return joinedEntities.Select(entity => (storage1.Get(entity),
                                                    storage2.Get(entity),
                                                    storage3.Get(entity),
                                                    storage4.Get(entity),
                                                    storage5.Get(entity),
                                                    entity));
        }
    }
}
