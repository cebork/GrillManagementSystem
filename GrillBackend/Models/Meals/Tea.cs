using GrillBackend.Models.Abstractions;

namespace GrillBackend.Models.Meals
{
    public class Tea : Drink
    {
        public Tea() { }
        public Tea(string name, int amount) : base(name, amount) { }

        public override void DrinkSomeDrink()
        {
            base.DrinkSomeDrink();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
