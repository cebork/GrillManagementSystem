using GrillBackend.Logic;
using GrillBackend.Models.GrillStuff;

namespace BackendTests
{
    [TestClass]
    public class GrillLogicTest
    {
        
        [TestMethod]
        public void AddNewGrillTest()
        {
            GrillLogic grillLogic = new GrillLogic();
            Grill grill = new Grill("Nazwa", DateTime.Now, Status.preparing);
            grillLogic.AddNewGrill(grill);
            int expectedValue = 1;
            Assert.AreEqual(grillLogic.GetGrillList().Count, expectedValue);
        }
    }
}