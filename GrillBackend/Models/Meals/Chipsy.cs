using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;

namespace GrillBackend.Models.Meals
{
    public class Chipsy : Food, INotGrillable
    {
        public Chipsy()
        {
        }

        public Chipsy(string name, int amount, int weight) : base(name, amount, weight)
        {
        }

        public void Feed()
        {
            if (Amount > 0)
            {
                Amount -= 1;
            }
            else
            {
                throw new NoFoodException("Nie ma już " + Name);
            }
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
