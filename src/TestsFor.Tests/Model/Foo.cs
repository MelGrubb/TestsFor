namespace TestsFor.Tests.Model
{
    public interface IFoo
    {
        public IBar Bar { get; set; }
        public string Name { get; set; }
    }

    public class Foo : IFoo
    {
        public Foo(IBar bar)
        {
            Bar = bar;
        }

        public IBar Bar { get; set; }
        public string Name { get; set; } = null!;
    }
}