using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;
using GrillBackend.Models.Meals;
using System.Xml.Serialization;

namespace GrillBackend.Models.GrillStuff
{
    [XmlInclude(typeof(BloodPudding))]
    [XmlInclude(typeof(ChuckSteak))]
    [XmlInclude(typeof(Kebab))]
    [XmlInclude(typeof(Sausage))]
    [XmlInclude(typeof(Bread))]
    [XmlInclude(typeof(Chipsy))]
    [XmlInclude(typeof(Tea))]
    [XmlInclude(typeof(Water))]
    [XmlInclude(typeof(Random))]
    [Serializable]
    public class Grill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfGrillStart { get; set; }
        public List<GrillMember> GrillMembers { get; set; }
        public Status Status { get; set; }
        public int MaxGrillCap { get; set; }
        public List<Meal> MealsPrepared { get; set; }
        public List<Food> MealsAtGrill { get; set; }
        public List<Food> MealsGrilled { get; set; }
        Random random = new Random();
        public Grill() { }
        public Grill(string name, DateTime? dateOfGrillStart, string description)
        {
            Name = name;
            DateOfGrillStart = dateOfGrillStart;
            GrillMembers = new List<GrillMember>();
            Status = Status.preparing;
            Description = description;
            MealsPrepared = new List<Meal>()
            {
                new BloodPudding("Kaszanka", random.Next(5, 10), 150),
                new ChuckSteak("Karkówka", random.Next(5, 10), 150),
                new Kebab("Szaszłyk", random.Next(5, 10), 150),
                new Sausage("Kiełbaska", random.Next(5, 10), 150),
                new Bread("Chleb", random.Next(5, 10), 150),
                new Chipsy("LejsyNieMax", random.Next(5,10), 150),
                new Tea("Herbata", random.Next(5, 10)),
                new Water("Woda", random.Next(5, 10))
            };
            MealsAtGrill = new List<Food>();
            MealsGrilled = new List<Food>();
            MaxGrillCap = 4850;
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
            string toString = "GRILL" +
                $"Name: {Name}" +
                $"Description: {Description}" +
                $"DateOfGrillStart: {DateOfGrillStart}" +
                $"Status: {Status}" +
                $"Members: ";
            foreach (var member in GrillMembers)
            {
                toString += member.ToString();
            }
            return toString;
        }
    }
}