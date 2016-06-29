using Xunit;

namespace ValueObjectHandsOn.Test
{
    public class ValueObjectWithoutReflectionTest
    {
        [Fact]
        public void ResultOfEquals_WhenTwoMoneyAreEquals_ShouldBeTrue()
        {
            //Arrange
            var money1 = new Money2(10m);
            var money2 = new Money2(10m);

            //Act
            var result = money1 == money2;

            //Assert
            Assert.Equal(result, true);
        }


        [Fact]
        public void ResultOfEqulityComparision_WhenTwoMoneyAreNotEqual_ShouldBeFalse()
        {
            //Arrange
            var money1 = new Money2(10m);
            var money2 = new Money2(20m);

            //Act
            var result = money1 == money2;

            //Assert
            Assert.Equal(result, false);
        }
    }
}
