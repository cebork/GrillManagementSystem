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
using System.Xml.Linq;
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
        public delegate void MealGrillMemberDelegate(Meal meal, GrillMember grillMember);
        public delegate void GrillMemberDelegate(GrillMember grillMember);
        public event MealGrillMemberDelegate OnMealGrillMemberDrinked;
        public event MealGrillMemberDelegate OnMealGrillMemberEatGrilled;
        public event MealGrillMemberDelegate OnMealGrillMemberEatNotGrilled;
        public GrillLogic()
        {
            try
            {
                using (FileStream fileStream = new FileStream("output.xml", FileMode.Open))
                {
                    grillList = (List<Grill>)serializer.Deserialize(fileStream);
                }
            }
            catch (FileNotFoundException ex)
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
            if (!string.IsNullOrEmpty(grillMember.Name) && !string.IsNullOrEmpty(grillMember.Surname) && !string.IsNullOrEmpty(grillMember.Email))
            {
                //if ((grillMember.Name == "" || grillMember.Name == null) && (grillMember.Surname == "" || grillMember.Surname == null) && (grillMember.Email == "" || grillMember.Email == null))
                //{
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
                    throw new GrillMemberAlreadyExistsException("Member już istnieje");
                }
                saveUpdatedData();
            }
            else
            {
                throw new WrongInputsException("Wprowadź dane");
            }

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

        public void FeedEveryoneWithGrillable(MealGrillMemberDelegate mealGrillMemberDelegate, GrillMemberDelegate grillMemberDelegate)
        {
            bool ifEated = false;
            foreach (var item in CurrentGrill.GrillMembers)
            {
                foreach (var meal in CurrentGrill.MealsGrilled)
                {
                    if (meal.Amount > 0)
                    {
                        ((IGrillable)meal).Feed();
                        mealGrillMemberDelegate(meal, item);
                        ifEated = true;
                        break;
                    }
                }
                if (!ifEated)
                {
                    grillMemberDelegate(item);
                }
                ifEated = false;
            }
        }

        public void ServeDrinkAll(MealGrillMemberDelegate mealGrillMemberDelegate, GrillMemberDelegate grillMemberDelegate)
        {
            bool ifDrinked = false;
            foreach (var item in CurrentGrill.GrillMembers)
            {
                foreach (var meal in CurrentGrill.MealsPrepared)
                {
                    if (meal.Amount > 0 && meal is Drink)
                    {
                        ((Drink)meal).DrinkSomeDrink();
                        mealGrillMemberDelegate(meal, item);
                        ifDrinked = true;
                        break;
                    }
                }
                if (!ifDrinked)
                {
                    grillMemberDelegate(item);
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

        public bool CheckIfTableContainsElementByName(Meal meal, List<Food> meals, bool isZdejmowany)
        {
            bool result = false;
            if (isZdejmowany)
            {
                foreach (var item in meals)
                {
                    string destTempLocal = meal.Name + " z grilla";
                    if (item.Name == destTempLocal)
                    {
                        result = true;
                    }
                }
            }
            else
            {
                foreach (var item in meals)
                {
                    if (item.Name == meal.Name)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
        public Meal FindMealByName(List<Meal> meals, string mealName)
        {
            return meals.Where(m => m.Name == mealName).First();
        }
        public Food FindFoodByName(List<Food> foods, string foodName)
        {
            return foods.Where(m => m.Name == foodName).First();
        }
        public void GiveMealToChosenOne(string meal, GrillMember grillMember)
        {
            if (meal != null && grillMember != null)
            {
                Meal result;
                if (meal.Contains(" z grilla"))
                {
                    result = FindFoodByName(CurrentGrill.MealsGrilled, meal);
                }
                else
                {
                    result = FindMealByName(CurrentGrill.MealsPrepared, meal);
                }

                if (result is Drink)
                {
                    ((Drink)result).DrinkSomeDrink();
                    OnMealGrillMemberDrinked.Invoke(result, grillMember);
                }
                else if (result is INotGrillable)
                {
                    ((INotGrillable)result).Feed();
                    OnMealGrillMemberEatNotGrilled.Invoke(result, grillMember);
                }
                else if (result is IGrillable)
                {
                    ((IGrillable)result).Feed();
                    OnMealGrillMemberEatGrilled.Invoke(result, grillMember);
                }
            }
            else
            {
                throw new MealOrMemberNotSelectedException("Nie wybrano grilowicza lub jedzenia");
            }

        }

        public int GetCurrentGrillWeight()
        {
            var result = CurrentGrill.MealsAtGrill.Sum(g => g.Weight * g.Amount);
            return result;
        }

        public void ChangeStack(IGrillable sourceMeal, List<Food> destinationMeals, bool isZdejmowany)
        {
            List<Food> mealsToAdd = new List<Food>();
            var result = GetCurrentGrillWeight();
            if (result <= CurrentGrill.MaxGrillCap || (isZdejmowany && result > 0))
            {
                if (((Food)sourceMeal).Amount != 0)
                {
                    if (destinationMeals.Count > 0)
                    {
                        if (CheckIfTableContainsElementByName((Food)sourceMeal, destinationMeals, isZdejmowany))
                        {
                            foreach (var item2 in destinationMeals)
                            {
                                if (isZdejmowany)
                                {
                                    string tempDest = ((Food)sourceMeal).Name + " z grilla";
                                    if (item2.Name == tempDest)
                                    {
                                        item2.Amount += 1;
                                        ((Food)sourceMeal).Amount -= 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (item2.Name == ((Food)sourceMeal).Name)
                                    {
                                        item2.Amount += 1;
                                        ((Food)sourceMeal).Amount -= 1;
                                        break;
                                    }
                                }

                            }
                        }
                        else
                        {
                            Food tempMeal = (Food)sourceMeal.Clone();
                            tempMeal.Amount = 0;
                            if (isZdejmowany)
                            {
                                tempMeal.Name += " z grilla";
                            }
                            mealsToAdd.Add(tempMeal);
                            tempMeal.Amount += 1;
                            ((Food)sourceMeal).Amount -= 1;
                        }
                    }
                    else
                    {
                        Food tempMeal = (Food)sourceMeal.Clone();
                        tempMeal.Amount = 0;
                        if (isZdejmowany)
                        {
                            tempMeal.Name += " z grilla";
                        }
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

        public List<string> CreateListOfMealsToSelect()
        {
            List<string> resultList = new List<string>();
            List<string> notGrillableList = CurrentGrill.MealsPrepared.Where(meal => meal is INotGrillable).Select(m => m.Name).ToList();
            List<string> drinkList = CurrentGrill.MealsPrepared.Where(meal => meal is Drink).Select(m => m.Name).ToList();
            List<string> mealsGirilledList = CurrentGrill.MealsGrilled.Where(meal => meal is IGrillable).Select(m => m.Name).ToList();
            resultList.AddRange(notGrillableList);
            resultList.AddRange(drinkList);
            resultList.AddRange(mealsGirilledList);
            return resultList;
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
