namespace GrillBackend.Models.Abstractions
{
    public abstract class Meal
    {
        public string? Name { get; set; }
        public int Amount { get; set; }

        public Meal() { }

        public Meal(string name, int amount)
        {
            Name = name;
            Amount = amount;
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
            return $"Name: {Name} Amount: {Amount}";
        }
    }
}
