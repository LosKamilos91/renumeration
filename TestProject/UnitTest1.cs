using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            renumeration_project.OtherFunctions.InMemoryEmployee employee1 = 
                new renumeration_project.OtherFunctions.InMemoryEmployee("Pawel", "Gawel");
            //act
            var result = $"{employee1.Name} {employee1.Surname}";
            //assert
            Assert.Equal("Pawel Gawel", result);
        }
    }
}