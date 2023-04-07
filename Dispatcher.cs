using System.Collections.Generic;

namespace ValiantECS
{
    public class Dispatcher
    {
        private List<ExecutionUnit> _systems;

        public Dispatcher()
        {
            _systems = new List<ExecutionUnit>();
        }

        public Dispatcher With(ISystem system, string name, params string[] dependencies)
        {
            _systems.Add(new ExecutionUnit
            {
                System = system,
                Name = name,
                Dependencies = new HashSet<string>(dependencies)
            });
            return this;
        }

        public void Dispatch(World world)
        {
            var executedSystems = new HashSet<string>();

            while (executedSystems.Count < _systems.Count)
            {
                foreach (var executionUnit in _systems)
                {
                    if (executedSystems.Contains(executionUnit.Name))
                    {
                        continue;
                    }

                    if (executionUnit.Dependencies.IsSubsetOf(executedSystems))
                    {
                        executionUnit.System.Run(world);
                        executedSystems.Add(executionUnit.Name);
                    }
                }
            }
        }

        private class ExecutionUnit
        {
            public ISystem System { get; set; }
            public string Name { get; set; }
            public HashSet<string> Dependencies { get; set; }
        }
    }

}
