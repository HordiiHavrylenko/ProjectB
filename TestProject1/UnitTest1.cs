using Microsoft.VisualStudio.TestPlatform.TestHost;
using ProjectB;
using System.Numerics;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateDriver_ValidInput_ShouldCreateDriver()
        {
            // Arrange
            string name = "John";
            int age = 25;
            CarBrand car = CarBrand.Audi;
            int id = 1;

            // Act
            Driver driver = new Driver(name, age, car, id);

            // Assert
            Assert.IsNotNull(driver);
            Assert.AreEqual(name, driver.Name);
            Assert.AreEqual(age, driver.Age);
            Assert.AreEqual(car, driver.Car);
            Assert.AreEqual(id, driver.Id);
        }

        [TestClass]
        public class TeamTests
        {
            [TestMethod]
            public void Team_NameShouldNotBeNullOrEmpty()
            {
                Team team = new Team("TestTeam");
                Assert.IsFalse(string.IsNullOrEmpty(team.TeamName));
            }

            [TestMethod]
            public void Team_NameShouldHaveAtLeastThreeCharacters()
            {


                Team team = new Team();

                string name = "Tm";
                Assert.ThrowsException<ArgumentException>(() => team.TeamName = name);
            }
        }     
        

        

        

        [TestMethod]
        public void Driver_age_less18()
        {
            int age = 10;            

            Driver newDriver = new Driver();

            Assert.ThrowsException<ArgumentException>(() => newDriver.Age = age);

        }

        

        [TestMethod]
        public void Coach_age_less18()
        {
            int age = 10;

            Coach newCoach = new Coach();

            Assert.ThrowsException<ArgumentException>(() => newCoach.Age = age);
        }

        


        [TestMethod]
        public void Coach_name_incorecct()
        {
            string name = "Jo";

            Coach newCoach = new Coach();
           

            //Act+Assert
            Assert.ThrowsException<ArgumentException>(() => newCoach.Name = name);
        }

        [TestMethod]
        public void Coach_name_corecct()
        {
            string name = "John";

            Coach newCoach = new Coach();
            newCoach.Name = name;

            //Act+Assert
            Assert.AreEqual(name, newCoach.Name);
        }


        public void Driver_name_incorecct()
        {
            string name = "Jo";

            Driver newDriver = new Driver();


            //Act+Assert
            Assert.ThrowsException<ArgumentException>(() => newDriver.Name = name);
        }

        [TestMethod]
        public void Driver_name_corecct()
        {
            string name = "John";

            Driver newDriver = new Driver();
            newDriver.Name = name;

            //Act+Assert
            Assert.AreEqual(name, newDriver.Name);
        }





    }
}