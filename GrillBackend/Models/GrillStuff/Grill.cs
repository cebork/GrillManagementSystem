using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;
using GrillBackend.Models.Meals;

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
            //MaxGrillCap = random.Next(2500,7500);
            MaxGrillCap = 5000;
            CreateRandomMealsList();
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
            //MealsPrepared.Add(new BloodPudding("Kaszanka", random.Next(5, 10), 150));
            //MealsPrepared.Add(new ChuckSteak("Karkówka", random.Next(5, 10), 150));
            //MealsPrepared.Add(new Kebab("Szaszłyk", random.Next(5, 10), 150));
            //MealsPrepared.Add(new Sausage("Kiełbaska", random.Next(5, 10), 150));
            //MealsPrepared.Add(new Tea("Herbata", random.Next(5, 10)));
            //MealsPrepared.Add(new Water("Woda", random.Next(5, 10)));

            //MealsAtGrill.Add(new BloodPudding("Kaszanka", 0, 150));
            //MealsAtGrill.Add(new ChuckSteak("Karkówka", 0, 150));
            //MealsAtGrill.Add(new Kebab("Szaszłyk", 0, 150));
            //MealsAtGrill.Add(new Sausage("Kiełbaska", 0, 150));

            //MealsGrilled.Add(new BloodPudding("Kaszanka", 0, 150));
            //MealsGrilled.Add(new ChuckSteak("Karkówka", 0, 150));
            //MealsGrilled.Add(new Kebab("Szaszłyk", 0, 150));
            //MealsGrilled.Add(new Sausage("Kiełbaska", 0, 150));
        }
    }
}