using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;
using GrillBackend.Models.GrillStuff;
using GrillBackend.Models.Meals;
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
        public event MealGrillMemberFeededDelegate MealGrillMemberDrinked;
        public event MealGrillMemberFeededDelegate MealGrillMemberEatGrilled;
        public event MealGrillMemberFeededDelegate MealGrillMemberEatNotGrilled;
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

        public void ServeDrinkAll(MealGrillMemberFeededDelegate mealGrillMemberFeededDelegate, MealGrillMemberNotFeededDelegate mealGrillMemberNotFeededDelegate)
        {
            bool ifDrinked = false;
            foreach (var item in CurrentGrill.GrillMembers)
            {
                foreach (var meal in CurrentGrill.MealsPrepared)
                {
                    if (meal.Amount > 0 && meal is Drink)
                    {
                        ((Drink)meal).DrinkSomeDrink();
                        mealGrillMemberFeededDelegate(meal, item);
                        ifDrinked = true;
                        break;
                    }
                }
                if (!ifDrinked)
                {
                    mealGrillMemberNotFeededDelegate(item);
                }
                ifDrinked = false;
            }
        }

        public void BuySomeMeals()
        {
            Random random = new Random();
            foreach (var item in CurrentGrill.MealsPrepared)
            {
                item.Amount += random.Next(2, 4);
            }
        }

        public bool CheckIfTableContainsElementByName(Meal meal, List<Food> meals)
        {
            bool result = false;
            foreach (var item in meals)
            {
                if (item.Name == meal.Name)
                {
                    result = true;
                }
            }
            return result;
        }

        public void GiveMealToChosenOne(Meal meal, GrillMember grillMember)
        {
            Meal result;
            if (meal is IGrillable)
            {
                result = (Meal)CurrentGrill.MealsGrilled.Where(m => m.Name == meal.Name);
                ((IGrillable)result).Feed();
                MealGrillMemberEatGrilled.Invoke(meal, grillMember);
            }
            if (meal is INotGrillable) 
            {
                result = (Meal)CurrentGrill.MealsPrepared.Where(m => m.Name == meal.Name);
                ((INotGrillable)result).Feed();
                MealGrillMemberEatNotGrilled.Invoke(meal, grillMember);
            }
            if (meal is Drink)
            {
                result = (Meal)CurrentGrill.MealsPrepared.Where(m => m.Name == meal.Name);
                ((Drink)result).DrinkSomeDrink();
                MealGrillMemberDrinked.Invoke(meal, grillMember);
            }
        }

        public int GetCurrentGrillWeight()
        {
            var result = CurrentGrill.MealsAtGrill.Sum(g => g.Weight * g.Amount);
            return result;
        }

        public void ChangeStack(IGrillable sourceMeal, List<Food> destinationMeals)
        {
            List<Food> mealsToAdd = new List<Food>();
            var result = GetCurrentGrillWeight();
            if (result <= CurrentGrill.MaxGrillCap)
            {
                if (((Food)sourceMeal).Amount != 0)
                {
                    if (destinationMeals.Count > 0)
                    {
                        foreach (var item in destinationMeals)
                        {

                            if (CheckIfTableContainsElementByName((Food)sourceMeal, destinationMeals))
                            {
                                foreach (var item2 in destinationMeals)
                                    if (item2.Name == ((Food)sourceMeal).Name)
                                    {
                                        item2.Amount += 1;
                                        ((Food)sourceMeal).Amount -= 1;
                                    }
                                break;
                            }
                            else
                            {
                                Food tempMeal = (Food)sourceMeal.Clone();
                                tempMeal.Amount = 0;
                                mealsToAdd.Add(tempMeal);
                                tempMeal.Amount += 1;
                                ((Food)sourceMeal).Amount -= 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Food tempMeal = (Food)sourceMeal.Clone();
                        tempMeal.Amount = 0;
                        mealsToAdd.Add(tempMeal);
                        tempMeal.Amount += 1;
                        ((Food)sourceMeal).Amount -= 1;
                    }
                    if (mealsToAdd.Count() != 0)
                    {
                        foreach (var mealToAdd in mealsToAdd)
                        {
                            destinationMeals.Add(mealToAdd);
                        }
                    }
                }
                else
                {
                    throw new NoFoodException(((Food)sourceMeal).Name + " <- To jedzenie skończyło się");
                }
            }
            else
            {
                throw new GrillOverflowException("Grill przepełniony nie można dodać więcej rzeczy");
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
