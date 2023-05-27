using GrillBackend.Models.Meals;
using GrillBackend.Models.Enums;
using GrillBackend.Logic;

namespace TestowaAplikacja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GrillLogic grillLogic = new GrillLogic();   
            Sausage x = new Sausage("123", SpicyLevel.spicy, 2 , 3);
            Sausage x2 = new Sausage("Nowa", SpicyLevel.spicy, 2, 3);
            grillLogic.PutMealOnGrill(x);
            grillLogic.PutMealOnGrill(x2);
        }
    }
}