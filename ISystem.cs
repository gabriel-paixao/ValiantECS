namespace ValiantECS
{
    public interface ISystem
    {
        void Run(World world, double elapsedGameTime);
    }
}
