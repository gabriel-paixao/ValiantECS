# ValiantECS

ValiantECS is a high-performance, engine-agnostic Entity Component System (ECS) library for C#. It's designed with simplicity, flexibility, and performance in mind, empowering developers to create games and applications with efficient and clean code.

## Usage

```Csharp
namespace ValiantECS.Tests
{
    public class Position
    {
        public double X;
        public double Y;
    }

    public class Velocity
    {
        public double X;
        public double Y;
    }

    public class Life
    {
        public int Value { get; set; }
    }

    public class HelloWorld : ISystem
    {
        public void Run(World world, double elapsedGameTime)
        {
            foreach (var (pos, _) in world.Join<Position>())
            {
                Console.WriteLine($"{pos.X} {pos.Y}");
            }
        }
    }
    public class UpdatePos : ISystem
    {
        public void Run(World world, double elapsedGameTime)
        {
            foreach (var (pos, vel, _) in world.Join<Position, Velocity>())
            {
                pos.X += vel.X * 0.05;
                pos.Y += vel.Y * 0.05;
            }
        }
    }

    public class Decay : ISystem
    {
        public void Run(World world, double elapsedGameTime)
        {
            foreach (var (life, entity) in world.Join<Life>())
            {
                if (life.Value <= 0)
                {
                    world.DeleteEntity(entity);
                }
                else
                {
                    life.Value -= 1;
                }
            }
        }
    }

    public class ExampleTests
    {
        [Fact]
        public void TestGame()
        {
            var world = new World();
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            world.RegisterComponent<Life>();

            world.CreateEntity()
            .With(new Position { X = 2, Y = 5 })
            .Build();

            world.CreateEntity()
            .With(new Position { X = 2, Y = 5 })
            .With(new Velocity { X = 0.1, Y = 0.2 })
            .Build();

            world.CreateEntity()
            .With(new Position { X = 10, Y = 9 })
            .With(new Velocity { X = 0.1, Y = 0.2 })
            .With(new Life { Value = 1 })
            .Build();

            var dispatcher = new Dispatcher()
                                .With(new HelloWorld(), "hello_world", new string[] { })
                                .With(new UpdatePos(), "update_pos", new[] { "hello_world" })
                                .With(new HelloWorld(), "hello_updated", new[] { "update_pos" })
                                .With(new Decay(), "decay", new string[] { });

            dispatcher.Dispatch(world, 0);
            dispatcher.Dispatch(world, 0);
            dispatcher.Dispatch(world, 0);
        }
    }
}
```

## Credits

ValiantECS is inspired by the [Amethyst Specs](https://github.com/amethyst/specs) project, an ECS library for Rust.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
