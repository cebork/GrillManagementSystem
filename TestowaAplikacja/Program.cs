using GrillBackend.Models.Meals;
using GrillBackend.Models.Enums;
using GrillBackend.Logic;
using GrillBackend.Models.GrillStuff;

namespace TestowaAplikacja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GrillLogic grillLogic = new GrillLogic();
            grillLogic.AddNewGrill(new Grill("test1", DateTime.Now, "opis1"));
            grillLogic.AddNewGrill(new Grill("test2", DateTime.Now, "opis2"));
            grillLogic.CurrentGrill = grillLogic.grillList[0];
            //grillLogic.AddNewMemeberToGrill(new GrillMember("Ala", "R", "alal@mail.com"));
            //grillLogic.AddNewMemeberToGrill(new GrillMember("Czarek", "B", "czarek@mail.com"));
            //grillLogic.AddNewMemeberToGrill(new GrillMember("Patrycja", "Z", "patrycja@mail.com"));
            //grillLogic.AddNewMemeberToGrill(new GrillMember("Paulina", "O", "paulina@mail.com"));
            //grillLogic.AddNewMemeberToGrill(new GrillMember("Kamil", "K", "kamil@mail.com"));
            grillLogic.CurrentGrill = grillLogic.grillList[1];
            //grillLogic.AddNewMemeberToGrill(new GrillMember("Paulina", "O", "paulina@mail.com"));
            //grillLogic.AddNewMemeberToGrill(new GrillMember("Kamil", "K", "kamil@mail.com"));
            grillLogic.CurrentGrill.CreateRandomMealsList();

            foreach (var item in grillLogic.CurrentGrill.MealsPrepared)
            {
                Console.WriteLine(item.Name + " " + item.Amount);
            }
            
            //Sausage x = new Sausage("123", SpicyLevel.spicy, 2 , 3);
            //Sausage x2 = new Sausage("Nowa", SpicyLevel.spicy, 2, 3);
            //grillLogic.PutMealOnGrill(x);
            //grillLogic.PutMealOnGrill(x2);
        }
    }
}