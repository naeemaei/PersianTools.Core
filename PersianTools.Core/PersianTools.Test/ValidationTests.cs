using PersianTools.Core;
using Xunit;

namespace PersianTools.Test

{
    public class ValidationTests
    {
        public ValidationTests()
        {

        }

        [Theory]
        [InlineData("0032546580")]
        public void When_NationalIdIsTrue_Then_ResultIsTrue(string nationalCode)
        {
            var validate = nationalCode.IsValidNationalCode();

            Assert.True(validate);
        }

        [Theory]
        [InlineData("0032546581")]
        public void When_NationalIdIsFalse_Then_ResultIsFalse(string nationalCode)
        {
            var validate = nationalCode.IsValidNationalCode();

            Assert.False(validate);
        }
    }
}