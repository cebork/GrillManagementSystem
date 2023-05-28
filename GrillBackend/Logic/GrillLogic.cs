using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.GrillStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBackend.Logic
{
    public class GrillLogic
    {
        private List<Grill> grillList = new List<Grill>();
        private Grill currentGrill;
        private Dictionary<Grillable, Thread> GrillableThreadDict = new Dictionary<Grillable, Thread>();

        public GrillLogic()
        {
            grillList.Add(new Grill("test1", DateTime.Now, "opis1"));
            grillList.Add(new Grill("test2", DateTime.Now, "opis2"));
        }
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
        public void PutMealOnGrill(Grillable grillable)
        {

            ThreadStart threadStart = new ThreadStart(grillable.GrillFood);
            Thread thread = new Thread(threadStart);
            GrillableThreadDict.Add(grillable, thread);
            thread.Start();
        }

        public void TakeMealFromGrill(Grillable grillable)
        {
            if (GrillableThreadDict.ContainsKey(grillable))
            {
                GrillableThreadDict.Remove(grillable);
                GrillableThreadDict.TryGetValue(grillable, out Thread thread);
                thread.Abort();
            }
        }

    }
}
