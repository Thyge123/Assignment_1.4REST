using Assignment_1._4_REST;
using Mandatory_assignment_1;

namespace UnitTest
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        //Arrange
        //Tjek at listen er blevet større (1 object mere end før)
        //Hvor mange elementer er der i listen
     
        FootballPlayer footballPlayer = new FootballPlayer(5, "Peter", 24, 15);

        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        [TestMethod()]
        public void Delete()
        {
            // Act
            _manager.Delete(5);
            int actual = _manager.GetAll().Count;
            int expected = 4;

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void AddTest()
        {
            //Act
            _manager.Add(footballPlayer);
            int expected = 5;
            int result = _manager.GetAll().Count;

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}