namespace TestsFor.Tests.Model
{
    public interface IBaz
    {
        public string Name { get; set; }
    }

    public class Baz : IBaz
    {
        public string Name { get; set; } = null!;
    }
}