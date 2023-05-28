﻿using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.GrillStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GrillBackend.Logic
{
    public class GrillLogic
    {
        public List<Grill> grillList { get; set; } = new List<Grill>();
        public Grill CurrentGrill { get; set; }
        private Dictionary<Grillable, Thread> GrillableThreadDict = new Dictionary<Grillable, Thread>();
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Grill>));
        public GrillLogic()
        {
            //grillList.Add(new Grill("test1", DateTime.Now, "opis1"));
            //grillList.Add(new Grill("test2", DateTime.Now, "opis2"));
            //CurrentGrill = grillList[0];
            //AddNewMemeberToGrill(new GrillMember("Ala", "R", "alal@mail.com"));
            //AddNewMemeberToGrill(new GrillMember("Czarek", "B", "czarek@mail.com"));
            //AddNewMemeberToGrill(new GrillMember("Patrycja", "Z", "patrycja@mail.com"));
            //AddNewMemeberToGrill(new GrillMember("Paulina", "O", "paulina@mail.com"));
            //AddNewMemeberToGrill(new GrillMember("Kamil", "K", "kamil@mail.com"));
            //CurrentGrill = grillList[1];
            //AddNewMemeberToGrill(new GrillMember("Ala", "R", "alal@mail.com"));
            try
            {
                using (FileStream fileStream = new FileStream("output.xml", FileMode.Open))
                {
                    grillList = (List<Grill>)serializer.Deserialize(fileStream);
                }
            }
            catch(FileNotFoundException ex)
            {
                saveUpdatedData();
            }
            
            
        }

        public void AddNewGrill(Grill grill)
        {
            grillList.Add(grill);
            saveUpdatedData();
        }

        public void RemoveGrill(Grill grill)
        {
            if (grillList.Contains(grill))
            {
                grillList.Remove(grill);
                saveUpdatedData();
            }
            else
            {
                throw new GrillNotExistException("Grill nie istnieje");
            }
        }

        public void AddNewMemeberToGrill(GrillMember grillMember)
        {
            CurrentGrill.GrillMembers.Add(grillMember);
            saveUpdatedData();
        }

        public void RemoveMemberFromGrill(GrillMember grillMember)
        {
            if (CurrentGrill.GrillMembers.Contains(grillMember))
            {
                CurrentGrill.GrillMembers.Remove(grillMember);
                saveUpdatedData();
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

        public void saveUpdatedData()
        {

            using (TextWriter writer = new StreamWriter("output.xml"))
            {
                serializer.Serialize(writer, grillList);
            }
        }
    }
}
