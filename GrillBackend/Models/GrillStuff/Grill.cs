using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;

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
        public List<Meal> MealsAtGrill { get; set; }

        public Grill() { }
        public Grill(string name, DateTime? dateOfGrillStart, string description)
        {
            Name = name;
            DateOfGrillStart = dateOfGrillStart;
            GrillMembers = new List<GrillMember>();
            Status = Status.preparing;
            Description = description;
            MealsAtGrill = new List<Meal>();
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
    }
}