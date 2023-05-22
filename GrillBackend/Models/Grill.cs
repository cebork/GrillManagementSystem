namespace GrillBackend.Models
{
    public class Grill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfGrillStart { get; set; }
        public List<GrillMember> GrillMembers { get; set; }

        public Grill() { }
        public Grill(string name, DateTime dateOfGrillStart, List<GrillMember> grillMembers)
        {
            Name = name;
            DateOfGrillStart = dateOfGrillStart;
            GrillMembers = grillMembers;
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
            string toString =  "GRILL" +
                $"Name: {Name}" +
                $"Description: {Description}" +
                $"DateOfGrillStart: {DateOfGrillStart}";
            foreach (var member in GrillMembers)
            {
                toString += member.ToString();
            }
            return toString;
        }
    }
}