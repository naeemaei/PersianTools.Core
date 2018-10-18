using System;
using Xunit;

namespace PersianTools.Test
{
    public class EnToFaDigitTest
    {
        public EnToFaDigitTest()
        {

        }
        [Fact]
        public void Test1()
        {
            int price = 11200000;
            string FaPrice = PersianTools.Core.CharacterUtil.Convert2(price);
            string FaPrice1 = PersianTools.Core.CharacterUtil.Convert(price);
            Assert.True(FaPrice1 == FaPrice.Replace(" ", ""));
        }
    }
}
