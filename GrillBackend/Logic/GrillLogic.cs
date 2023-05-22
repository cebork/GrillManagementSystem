using GrillBackend.Exceptions;
using GrillBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Logic
{
    public class GrillLogic
    {
        List<Grill> grillList = new List<Grill>();
        Grill currentGrill;
        public GrillLogic() { }
        public List<Grill> GetGrillList()
        {
            return grillList;
        }
        public void AddNewGrill(Grill grill)
        {
            grillList.Add(grill);
        }
        public void RemoveGrill(Grill grill)
        {
            if (grillList.Contains(grill))
            {
                grillList.Remove(grill);
            }
            else
            {
                throw new GrillNotExistException("Grill nie istnieje");
            }
        }
        public void ChooseGrill(Grill grill)
        {
            if (grillList.Contains(grill))
            {
                currentGrill = grill;
            }
            else
            {
                throw new GrillNotExistException("Grill nie istnieje");
            }
        }

        public List<GrillMember> GetGrillMembers()
        {
            return currentGrill.GrillMembers;
        }
        public void AddNewMemeberToGrill(GrillMember grillMember)
        {
            currentGrill.GrillMembers.Add(grillMember);
        }
        public void RemoveMemberFromGrill(GrillMember grillMember)
        {
            if (currentGrill.GrillMembers.Contains(grillMember))
            {
                currentGrill.GrillMembers.Remove(grillMember);
            }
            else
            {
                throw new GrillMemeberNotExistException("Ten uczestnik grilla nie istnieje");
            }
        }
    }
}
