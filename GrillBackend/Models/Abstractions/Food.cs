namespace GrillBackend.Models.Abstractions
{
    public abstract class Food : Meal
    {
        public int Weight { get; set; }
        public Food() { }

        protected Food(string name, int amount, int weight) : base(name, amount)
        {
            Weight = weight;
        }

        public override bool Equals(object? obj)
        {
            return ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString() + $"Weight: {Weight}";
        }
    }
}
