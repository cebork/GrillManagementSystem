using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;
using GrillBackend.Models.Meals;

namespace GrillBackend.Models.GrillStuff
{
    [Serializable]
    public class Grill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfGrillStart { get; set; }
        public List<GrillMember> GrillMembers { get; set; }
        public Status Status { get; set; }
        public int MaxGrillCap { get; set; }
        [XmlIgnore]
        public Dictionary<Meal, int> MealsPrepared { get; set; }
        [XmlIgnore]
        public Dictionary<Meal, int> MealsAtGrill { get; set; }
        [XmlIgnore]
        public Dictionary<Meal, int> MealsGrilled { get; set; }
        
        public Grill() { }
        public Grill(string name, DateTime? dateOfGrillStart, string description)
        {
            Name = name;
            DateOfGrillStart = dateOfGrillStart;
            GrillMembers = new List<GrillMember>();
            Status = Status.preparing;
            Description = description;
            MealsPrepared = new Dictionary<Meal, int>();
            MealsAtGrill = new Dictionary<Meal, int>();
            MealsGrilled = new Dictionary<Meal, int>();
            Random random = new Random();
            MaxGrillCap = random.Next(2500,7500);
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
                $"Status: {Status}";
            foreach (var member in GrillMembers)
            {
                toString += member.ToString();
            }
            return toString;
        }

        public void CreateRandomMealsList()
        {
            Random random = new Random();
            MealsPrepared.Add(new BloodPudding("Kaszanka", random.Next(100, 200)), random.Next(GrillMembers.Count, 2 * GrillMembers.Count));
            MealsPrepared.Add(new ChuckSteak("Karkówka", random.Next(100, 200)), random.Next(GrillMembers.Count, 2 * GrillMembers.Count));
            MealsPrepared.Add(new Kebab("Szaszłyk", random.Next(100, 200)), random.Next(GrillMembers.Count, 2 * GrillMembers.Count));
            MealsPrepared.Add(new Sausage("Kiełbaska", random.Next(100, 200)), random.Next(GrillMembers.Count, 2 * GrillMembers.Count));
            MealsPrepared.Add(new Tea("Herbata", random.Next(100, 200)), random.Next(GrillMembers.Count, 2 * GrillMembers.Count));
            MealsPrepared.Add(new Water("Woda", random.Next(100, 200)), random.Next(GrillMembers.Count, 2 * GrillMembers.Count));
        }
    }
}