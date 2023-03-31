namespace ValiantECS.Example
{
    public class Game
    {
        public void Start()
        {
            var world = new World();

            var hero = world.CreateEntity();
            world.AddComponent(hero, new PositionComponent { X = 0, Y = 0 });
            world.AddComponent(hero, new HealthComponent { Current = 100, Max = 100 });
            world.AddComponent(hero, new MoveComponent { Speed = 2 });

            var healthSystem = new HealthSystem(world.EntityManager, world.ComponentManager);
            var moveSystem = new MoveSystem(world.EntityManager, world.ComponentManager);
            world.AddSystem(healthSystem);
            world.AddSystem(moveSystem);

            moveSystem.MoveEntity(hero, 2, 2); // Move hero 2 units right and 2 units up
            var heroHealth = world.GetComponent<HealthComponent>(hero);
            heroHealth.Current -= 10; // Hero takes 10 damage            
            world.Update(); // Update all systems

            return hero;
        }
    }
}
