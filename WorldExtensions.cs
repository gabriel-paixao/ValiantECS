using System.Collections.Generic;
using System.Linq;

namespace ValiantECS
{
    public static class WorldExtensions
    {
        public static IEnumerable<(T1, Entity)> Join<T1>(this World world)
           where T1 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, Entity)>)cachedResult;
            }
            var storage1 = world.GetComponentStorage<T1>();

            var entities1 = storage1.GetEntities();
            
            var result = entities1.Select(entity => (storage1.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, Entity)> Join<T1, T2>(this World world)
            where T1 : new()
            where T2 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();

            var joinedEntities = entities1.Intersect(entities2);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, Entity)> Join<T1, T2, T3>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, T4, Entity)> Join<T1, T2, T3, T4>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
            where T4 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3), typeof(T4));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, T4, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), storage4.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, T4, T5, Entity)> Join<T1, T2, T3, T4, T5>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
            where T4 : new()
            where T5 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, T4, T5, Entity)>)cachedResult;
            }

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

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4).Intersect(entities5);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), storage4.Get(entity), storage5.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, T4, T5, T6, Entity)> Join<T1, T2, T3, T4, T5, T6>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
            where T4 : new()
            where T5 : new()
            where T6 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, T4, T5, T6, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();
            var storage5 = world.GetComponentStorage<T5>();
            var storage6 = world.GetComponentStorage<T6>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();
            var entities5 = storage5.GetEntities();
            var entities6 = storage6.GetEntities();

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4).Intersect(entities5).Intersect(entities6);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), storage4.Get(entity), storage5.Get(entity), storage6.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, T4, T5, T6, T7, Entity)> Join<T1, T2, T3, T4, T5, T6, T7>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
            where T4 : new()
            where T5 : new()
            where T6 : new()
            where T7 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, T4, T5, T6, T7, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();
            var storage5 = world.GetComponentStorage<T5>();
            var storage6 = world.GetComponentStorage<T6>();
            var storage7 = world.GetComponentStorage<T7>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();
            var entities5 = storage5.GetEntities();
            var entities6 = storage6.GetEntities();
            var entities7 = storage7.GetEntities();

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4).Intersect(entities5).Intersect(entities6).Intersect(entities7);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), storage4.Get(entity), storage5.Get(entity), storage6.Get(entity), storage7.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, Entity)> Join<T1, T2, T3, T4, T5, T6, T7, T8>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
            where T4 : new()
            where T5 : new()
            where T6 : new()
            where T7 : new()
            where T8 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();
            var storage5 = world.GetComponentStorage<T5>();
            var storage6 = world.GetComponentStorage<T6>();
            var storage7 = world.GetComponentStorage<T7>();
            var storage8 = world.GetComponentStorage<T8>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();
            var entities5 = storage5.GetEntities();
            var entities6 = storage6.GetEntities();
            var entities7 = storage7.GetEntities();
            var entities8 = storage8.GetEntities();

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4).Intersect(entities5).Intersect(entities6).Intersect(entities7).Intersect(entities8);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), storage4.Get(entity), storage5.Get(entity), storage6.Get(entity), storage7.Get(entity), storage8.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, Entity)> Join<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
            where T4 : new()
            where T5 : new()
            where T6 : new()
            where T7 : new()
            where T8 : new()
            where T9 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();
            var storage5 = world.GetComponentStorage<T5>();
            var storage6 = world.GetComponentStorage<T6>();
            var storage7 = world.GetComponentStorage<T7>();
            var storage8 = world.GetComponentStorage<T8>();
            var storage9 = world.GetComponentStorage<T9>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();
            var entities5 = storage5.GetEntities();
            var entities6 = storage6.GetEntities();
            var entities7 = storage7.GetEntities();
            var entities8 = storage8.GetEntities();
            var entities9 = storage9.GetEntities();

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4).Intersect(entities5).Intersect(entities6).Intersect(entities7).Intersect(entities8).Intersect(entities9);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), storage4.Get(entity), storage5.Get(entity), storage6.Get(entity), storage7.Get(entity), storage8.Get(entity), storage9.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }

        public static IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Entity)> Join<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this World world)
            where T1 : new()
            where T2 : new()
            where T3 : new()
            where T4 : new()
            where T5 : new()
            where T6 : new()
            where T7 : new()
            where T8 : new()
            where T9 : new()
            where T10 : new()
        {
            var cacheKey = world.GenerateJoinCacheKey(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10));
            if (world.JoinCache.TryGetValue(cacheKey, out object cachedResult))
            {
                return (IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Entity)>)cachedResult;
            }

            var storage1 = world.GetComponentStorage<T1>();
            var storage2 = world.GetComponentStorage<T2>();
            var storage3 = world.GetComponentStorage<T3>();
            var storage4 = world.GetComponentStorage<T4>();
            var storage5 = world.GetComponentStorage<T5>();
            var storage6 = world.GetComponentStorage<T6>();
            var storage7 = world.GetComponentStorage<T7>();
            var storage8 = world.GetComponentStorage<T8>();
            var storage9 = world.GetComponentStorage<T9>();
            var storage10 = world.GetComponentStorage<T10>();

            var entities1 = storage1.GetEntities();
            var entities2 = storage2.GetEntities();
            var entities3 = storage3.GetEntities();
            var entities4 = storage4.GetEntities();
            var entities5 = storage5.GetEntities();
            var entities6 = storage6.GetEntities();
            var entities7 = storage7.GetEntities();
            var entities8 = storage8.GetEntities();
            var entities9 = storage9.GetEntities();
            var entities10 = storage10.GetEntities();

            var joinedEntities = entities1.Intersect(entities2).Intersect(entities3).Intersect(entities4).Intersect(entities5).Intersect(entities6).Intersect(entities7).Intersect(entities8).Intersect(entities9).Intersect(entities10);

            var result = joinedEntities.Select(entity => (storage1.Get(entity), storage2.Get(entity), storage3.Get(entity), storage4.Get(entity), storage5.Get(entity), storage6.Get(entity), storage7.Get(entity), storage8.Get(entity), storage9.Get(entity), storage10.Get(entity), entity));
            world.JoinCache[cacheKey] = result;
            return result;
        }
    }
}
