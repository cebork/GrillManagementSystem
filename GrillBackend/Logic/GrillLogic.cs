using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;
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
        public List<GrillMember> MemberList { get; set; }

        private Dictionary<IGrillable, Thread> GrillableThreadDict = new Dictionary<IGrillable, Thread>();
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Grill>));
        public delegate void MealGrillMemberFeededDelegate(Meal meal, GrillMember grillMember);
        public delegate void MealGrillMemberNotFeededDelegate(GrillMember grillMember);
        public GrillLogic()
        {
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

        public void AddNewMember(GrillMember grillMember)
        {
            if (!CurrentGrill.GrillMembers.Contains(grillMember))
            {
                CurrentGrill.GrillMembers.Add(grillMember);
            }
            if (!MemberList.Contains(grillMember))
            {
                MemberList.Add(grillMember);
            }
            else
            {
                throw new GrillMemberAlreadyExistsException("Member już istniej");
            }
            saveUpdatedData();
        }

        public void AddNewMemeberToGrill(GrillMember grillMember)
        {
            CurrentGrill.GrillMembers.Add(grillMember);
            saveUpdatedData();
        }

        public void GetAllGrillMembersDistincted()
        {
            MemberList = grillList.SelectMany(grill => grill.GrillMembers).Distinct().ToList();
        }

        public void EditGrill(string name, string description, DateTime grillStart, List<GrillMember> grillMembers)
        {
            CurrentGrill.Name = name;
            CurrentGrill.Description = description;
            CurrentGrill.DateOfGrillStart = grillStart;
            CurrentGrill.GrillMembers = grillMembers;
            saveUpdatedData();
        }

        public void ChangeStatus(Status status)
        {
            CurrentGrill.Status = status;
            saveUpdatedData();
        }

        public void ChangeStack<T>(ref IGrillable sourceMeal, ref List<T> destinationList) where T : Meal, IGrillable // ref moze byc to wywalenia jakby cos nie działało
        {
            if (((Meal)sourceMeal).Amount != 0)
            {
                foreach (var item in destinationList)
                {
                    if (item.Name == ((Meal)sourceMeal).Name)
                    {
                        item.Amount -= 1;
                        ((Meal)sourceMeal).Amount += 1;
                        break;
                    }
                }
            }
            else
            {
                throw new NoFoodException(((Meal)sourceMeal).Name + " <- Tego jedzenia nie ma już na grillu");
            }
        }

        public void FeedEveryoneWithGrillable(MealGrillMemberFeededDelegate mealGrillMemberFeededDelegate, MealGrillMemberNotFeededDelegate mealGrillMemberNotFeededDelegate)
        {
            bool ifEated = false;
            foreach (var item in CurrentGrill.GrillMembers)
            {
                foreach (var meal in CurrentGrill.MealsGrilled)
                {
                    if (meal.Amount > 0)
                    {
                        ((IGrillable)meal).Feed();
                        mealGrillMemberFeededDelegate(meal, item);
                        ifEated = true;
                        break;
                    }
                }
                if (!ifEated)
                {
                    mealGrillMemberNotFeededDelegate(item);
                }
                ifEated = false;
            }
        }

        public void BuySomeMeals()
        {

        }

        public void PutMealOnGrill(IGrillable grillable)
        {
            if (((Meal)grillable).Amount != 0)
            {
                foreach (var item in CurrentGrill.MealsAtGrill)
                {
                    if (item.Name == ((Meal)grillable).Name)
                    {
                        item.Amount += 1;
                        ((Meal)grillable).Amount -= 1;
                    }
                }
            }
            else
            {
                throw new NoFoodException(((Meal)grillable).Name + " <- To jedzenie skończyło się");
            }
        }

        public void TakeMealFromGrill(IGrillable grillable)
        {
            if (((Meal)grillable).Amount != 0)
            {
                foreach (var item in CurrentGrill.MealsGrilled)
                {
                    if (item.Name == ((Meal)grillable).Name)
                    {
                        item.Amount += 1;
                        ((Meal)grillable).Amount -= 1;
                    }
                }
            }
            else
            {
                throw new NoFoodException(((Meal)grillable).Name + " <- Tego jedzenia nie ma już na grillu");
            }
        }


        //public void PutMealOnGrill(IGrillable grillable)
        //{

        //    ThreadStart threadStart = new ThreadStart(grillable.GrillFood);
        //    Thread thread = new Thread(threadStart);
        //    GrillableThreadDict.Add(grillable, thread);
        //    thread.Start();
        //}

        //public void TakeMealFromGrill(IGrillable grillable)
        //{
        //    if (GrillableThreadDict.ContainsKey(grillable))
        //    {
        //        GrillableThreadDict.Remove(grillable);
        //        GrillableThreadDict.TryGetValue(grillable, out Thread thread);
        //        thread.Abort();
        //    }
        //}

        public void saveUpdatedData()
        {

            using (TextWriter writer = new StreamWriter("output.xml"))
            {
                serializer.Serialize(writer, grillList);
            }
        }
    }
}
