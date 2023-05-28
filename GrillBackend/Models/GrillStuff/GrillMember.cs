using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Models.GrillStuff
{
    public class GrillMember
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public GrillMember() { }

        public GrillMember(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
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
            return "GRILL MEMBER" +
                $"Name: {Name}" +
                $"Surname: {Surname}" +
                $"Email: {Email}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
