namespace TestsFor.Tests.Model
{
    public interface IBar
    {
        public IBaz? Baz { get; set; }
        public string Name { get; set; }
    }

    public class Bar : IBar
    {
        public Bar(IBaz baz)
        {
            Baz = baz;
        }

        public IBaz? Baz { get; set; }
        public string Name { get; set; } = null!;
    }
}