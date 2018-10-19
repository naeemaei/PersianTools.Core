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
            string FaPrice = "یازده میلیون و دویست هزار".Replace(" ", "");
            string FaPrice1 = PersianTools.Core.CharacterUtil.Convert(price).Replace(" ", "");
            Assert.Equal(FaPrice,FaPrice1);
        }
    }
}
